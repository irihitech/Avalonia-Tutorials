using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Data;
using Avalonia.Data.Core.Plugins;
using Avalonia.Utilities;

namespace DataGrid_With_DataTable;

public class DataTablePropertyAccessorPlugin: IPropertyAccessorPlugin
{
    public bool Match(object obj, string propertyName)
    {
        if (obj is DataRow t)
        {
            return t.Table.Columns.Contains(propertyName);
        }
        return false;
    }

    public IPropertyAccessor? Start(WeakReference<object?> reference, string propertyName)
    {
        _ = reference ?? throw new ArgumentNullException(nameof(reference));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));

        if (!reference.TryGetTarget(out var instance) || instance is null)
            return null;

        bool valid = true;

        if (valid)
        {
            return new DataTableAccessor(reference, propertyName);
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
class DataTableAccessor : PropertyAccessorBase, IWeakEventSubscriber<PropertyChangedEventArgs>
{
    private readonly WeakReference<object?> _reference;
    private readonly string _propertyName;
    private bool _eventRaised;
    
    public DataTableAccessor(WeakReference<object?> reference, string propertyName)
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
    
    private DataRow? GetReferenceTarget()
    {
        _reference.TryGetTarget(out var target);
        return target as DataRow;
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