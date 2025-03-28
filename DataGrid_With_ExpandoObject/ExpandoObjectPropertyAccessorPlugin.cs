using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Data;
using Avalonia.Data.Core.Plugins;
using Avalonia.Utilities;

namespace DataGrid_With_ExpandoObject;

public class ExpandoObjectPropertyAccessorPlugin: IPropertyAccessorPlugin
{
    public bool Match(object obj, string propertyName)
    {
        if (obj is IDictionary<string, object> t)
        {
            return t.ContainsKey(propertyName);
        }
        return false;
    }

    public IPropertyAccessor? Start(WeakReference<object?> reference, string propertyName)
    {
        _ = reference ?? throw new ArgumentNullException(nameof(reference));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));

        if (!reference.TryGetTarget(out var instance) || instance is null)
            return null;

        bool valid = instance as IDictionary<string, object> is { } dict && dict.ContainsKey(propertyName);

        if (valid)
        {
            return new ExpandoObjectAccessor(reference, propertyName);
        }
        else
        {
            var message = $"Could not find CLR property '{propertyName}' on '{instance}'";
            var exception = new MissingMemberException(message);
            return new PropertyError(new BindingNotification(exception, BindingErrorType.Error));
        }
    }
}

[RequiresUnreferencedCode("PropertyAccessors might require unreferenced code.")]
class ExpandoObjectAccessor : PropertyAccessorBase, IWeakEventSubscriber<PropertyChangedEventArgs>
{
    private readonly WeakReference<object?> _reference;
    private readonly string _propertyName;
    private bool _eventRaised;
    
    public ExpandoObjectAccessor(WeakReference<object?> reference, string propertyName)
    {
        _ = reference ?? throw new ArgumentNullException(nameof(reference));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
    
        _reference = reference;
        _propertyName = propertyName;
    }
    
    public override Type? PropertyType => typeof(object);
    
    public override object? Value
    {
        get
        {
            var o = GetReferenceTarget();
            return o?[_propertyName];
        }
    }
    
    public override bool SetValue(object? value, BindingPriority priority)
    {
        _eventRaised = false;
        var target = GetReferenceTarget();
        if (target is not null)
        {
            target[_propertyName] = value;
        }
        if (!_eventRaised)
        {
            SendCurrentValue();
        }
        return true;
    }
    
    public void OnEvent(object? notifyPropertyChanged, WeakEvent ev, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == _propertyName || string.IsNullOrEmpty(e.PropertyName))
        {
            _eventRaised = true;
            SendCurrentValue();
        }
    }
    
    protected override void SubscribeCore()
    {
        SubscribeToChanges();
        SendCurrentValue();
    }
    
    protected override void UnsubscribeCore()
    {
        if (GetReferenceTarget() is INotifyPropertyChanged inpc)
            WeakEvents.ThreadSafePropertyChanged.Unsubscribe(inpc, this);
    }
    
    private IDictionary<string, object?>? GetReferenceTarget()
    {
        _reference.TryGetTarget(out var target);
        return target as IDictionary<string, object?>;
    }
    
    private void SendCurrentValue()
    {
        try
        {
            var value = Value;
            PublishValue(value);
        }
        catch
        {
            // ignored
        }
    }
    
    private void SubscribeToChanges()
    {
        if (GetReferenceTarget() is INotifyPropertyChanged inpc)
            WeakEvents.ThreadSafePropertyChanged.Subscribe(inpc, this);
    }
}