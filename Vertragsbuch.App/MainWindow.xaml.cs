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
            var vertragsName = VertragsNameTextBox.Text.Trim(); // Enfernt Leerzeichen 

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

        private void EntfernenButton_Click(object sender, RoutedEventArgs e)
        {
            string? ausgewaehlterVertrag = VertragsListBox.SelectedItem as string; // Gibt dem Ausgwählten Text als String zurück oder null
            if (ausgewaehlterVertrag != null)
            {
                VertragsListBox.Items.Remove(ausgewaehlterVertrag); // löscht den Ausgewählten Text aus der Box

            }
            else
            {
                MessageBox.Show("Bitte wählen sie zuerst ein Vertrag aus");
            }
        }
    }
}