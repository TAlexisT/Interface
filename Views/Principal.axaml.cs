using Avalonia.Controls;

namespace PracticaInt.Views
{
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }
        void ArbolB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ArbolV x = new ArbolV();
            x.Show();
            this.Close();
        }
        void GrafoB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            GrafoV x = new GrafoV();
            x.Show();
            this.Close();
        }
    }
}
