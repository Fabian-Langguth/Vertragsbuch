using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vertragsbuch.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HinzufuegenButton_Click(object sender, RoutedEventArgs e)
        {
            var vertragsName = VertragsNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(vertragsName))
            {
                MessageBox.Show("Das Feld darf nicht leer sein.");
            }
            else
            {
                VertragsListBox.Items.Add(vertragsName);
                VertragsNameTextBox.Clear();
            }
            VertragsNameTextBox.Focus();


        }
    }
}