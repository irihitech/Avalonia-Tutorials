namespace WinFormsApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var window = new Avalonia.Controls.Window();
        window.Content = "Hello Avalonia!";
        window.Show();
    }
}