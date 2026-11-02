using Avalonia.Controls;
using Avalonia.Interactivity;

namespace client.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void QuitButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
{
    Close();
}

}
