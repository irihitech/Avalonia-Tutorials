using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace Handle_TextBox_Input;

public class ScannerTextBox: TextBox
{
    protected override Type StyleKeyOverride { get; } = typeof(TextBox);

    protected override void OnTextInput(TextInputEventArgs e)
    {
        e.Handled = true;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.Handled) return;
        switch (e.Key)
        {
            case >= Key.D0 and <= Key.D9:
            {
                var s = (e.Key - Key.D0).ToString();
                InsertText(s);
                e.Handled = true;
                break;
            }
            case >= Key.A and < Key.Z:
            {
                var s = e.Key.ToString();
                InsertText(s);
                e.Handled = true;
                break;
            }
            case >= Key.NumPad0 and <= Key.NumPad9:
            {
                var s = (e.Key - Key.NumPad0).ToString();
                InsertText(s);
                e.Handled = true;
                break;
            }
        }
    }

    private void InsertText(string s)
    {
        var index = CaretIndex;
        if (string.IsNullOrEmpty(Text))
        {
            Text = s;
        }
        else
        {
            Text = Text?.Insert(index, s);
        }

        CaretIndex += s.Length;
    }
}