using System.Windows;

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
            AnzahlAktualisieren();
        }

        private void HinzufuegenButton_Click(object sender, RoutedEventArgs e)
        {
            var vertragsName = VertragsNameTextBox.Text.Trim(); // Enfernt Leerzeichen 
            bool istVorhanden = false;
            foreach (string eintrag in VertragsListBox.Items) // Durchläuft die Listbox,sucht nach vorhanden Verträgen
            {
                if (string.Equals(eintrag, vertragsName, StringComparison.OrdinalIgnoreCase))
                {
                    istVorhanden = true;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(vertragsName)) // Prüft ob Eingabe leer ist
            {
                MessageBox.Show("Das Feld darf nicht leer sein.");
            }
            else if(istVorhanden) // Prüft ob Vertrag schon existiert
            {
                MessageBox.Show("Der Vertrag ist schon vorhanden.");
                
            }
            else // Fügt Vertrag hinzu
            {
                VertragsListBox.Items.Add(vertragsName);
                VertragsNameTextBox.Clear();
                AnzahlAktualisieren();
            }
            VertragsNameTextBox.Focus();

        }

        private void EntfernenButton_Click(object sender, RoutedEventArgs e)
        {
            string? ausgewaehlterVertrag = VertragsListBox.SelectedItem as string; // Gibt dem Ausgwählten Text als String zurück oder null
            if (ausgewaehlterVertrag != null)
            {
                MessageBoxResult antwort =
                MessageBox.Show($"Möchten sie {ausgewaehlterVertrag} wirklich löschen?",
                    "Vertrag Entfernen?",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (antwort == MessageBoxResult.Yes)
                {
                    VertragsListBox.Items.Remove(ausgewaehlterVertrag); // löscht den Ausgewählten Text aus der Box
                    AnzahlAktualisieren();
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie zuerst einen Vertrag aus.");
            }
        }

        private void AnzahlAktualisieren()
        {
            int anzahlVertraege = VertragsListBox.Items.Count;
            AnzahlTextBlock.Text = $"Anzahl: {anzahlVertraege}";

            if (anzahlVertraege == 0 || anzahlVertraege > 1)
            {
                AnzahlTextBlock.Text = $"{anzahlVertraege} Verträge";
            }
            else
            {
                AnzahlTextBlock.Text = $"{anzahlVertraege} Vertrag";
            }
        }
    }
}