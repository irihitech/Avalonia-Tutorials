using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Handle_TextBox_Input;


public class ScannerTextBox: TextBox
{
    protected override Type StyleKeyOverride { get; } = typeof(TextBox);
    
    static ScannerTextBox()
    {
        TextInputEvent.AddClassHandler<ScannerTextBox>(OnScannerTextInput, RoutingStrategies.Tunnel);
        KeyDownEvent.AddClassHandler<ScannerTextBox>(OnScannerKeyDown, RoutingStrategies.Tunnel);
        TextInputMethodClientRequestedEvent.AddClassHandler<ScannerTextBox>((box, args) =>
            args.Client = null, RoutingStrategies.Tunnel);
    }

    private static void OnScannerKeyDown(ScannerTextBox arg1, KeyEventArgs arg2)
    {
        arg1.OnKeyDown(arg2);
        if (arg2.Handled) return;
        switch (arg2.PhysicalKey)
        {
            case >= PhysicalKey.Digit0 and <= PhysicalKey.Digit9:
            {
                var s = (arg2.PhysicalKey - PhysicalKey.Digit0).ToString();
                arg1.InsertText(s);
                arg2.Handled = true;
                break;
            }
            case >= PhysicalKey.A and <= PhysicalKey.Z:
            {
                var s = arg2.PhysicalKey.ToString();
                arg1.InsertText(s);
                arg2.Handled = true;
                break;
            }
            case >= PhysicalKey.NumPad0 and <= PhysicalKey.NumPad9:
            {
                var s = (arg2.PhysicalKey - PhysicalKey.NumPad0).ToString();
                arg1.InsertText(s);
                arg2.Handled = true;
                break;
            }
            case PhysicalKey.Enter or PhysicalKey.NumPadEnter:
            {
                Debug.WriteLine("RETURN");
                break;                
            }
        }
    }

    private static void OnScannerTextInput(ScannerTextBox arg1, TextInputEventArgs arg2)
    {
        arg2.Handled = true;
    }

    protected override void OnTextInput(TextInputEventArgs e)
    {
        e.Handled = true;
    }

    private void InsertText(string s)
    {
        var caretIndex = CaretIndex;
        if(SelectionStart != SelectionEnd)
        {
            Text = Text?.Remove(SelectionStart, SelectionEnd - SelectionStart);
            CaretIndex = SelectionStart;
        }
        Text = string.IsNullOrEmpty(Text) ? s : Text.Insert(caretIndex, s);
        CaretIndex += s.Length;
    }
}