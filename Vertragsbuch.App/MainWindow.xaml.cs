using System.Windows;
using Vertragsbuch.App.Models;

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
            var vertragsName = VertragsNameTextBox.Text.Trim(); // Entfernt Leerzeichen 
            if (string.IsNullOrWhiteSpace(vertragsName)) // Prüft ob Eingabe leer ist
            {
                MessageBox.Show("Das Feld darf nicht leer sein.");
            }
            else if (IstVertragVorhanden(vertragsName)) // Prüft ob Vertrag schon existiert
            {
                MessageBox.Show("Der Vertrag ist schon vorhanden.");
            }
            else // Fügt Vertrag hinzu
            {
                Vertrag vertrag = new Vertrag();
                vertrag.Name = vertragsName;
                VertragsListBox.Items.Add(vertrag);
                VertragsNameTextBox.Clear();
                AnzahlAktualisieren();
            }
            VertragsNameTextBox.Focus();
        }

        private bool IstVertragVorhanden(string vertragsName)
        {
            foreach (Vertrag eintrag in VertragsListBox.Items) // Durchläuft die Listbox,sucht nach vorhanden Verträgen
            {
                if (string.Equals(eintrag.Name, vertragsName, StringComparison.OrdinalIgnoreCase)) // ignoriert groß und kleinschreibung
                {
                    return true;
                }
            }
            return false;
        }

        private void EntfernenButton_Click(object sender, RoutedEventArgs e)
        {
            Vertrag? ausgewaehlterVertrag = VertragsListBox.SelectedItem as Vertrag; // Gibt den ausgewählten Vertrag zurück oder null
            if (ausgewaehlterVertrag != null)
            {
                MessageBoxResult antwort =
                MessageBox.Show($"Möchten Sie {ausgewaehlterVertrag.Name} wirklich löschen?",
                    "Vertrag Entfernen?",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (antwort == MessageBoxResult.Yes)
                {
                    VertragsListBox.Items.Remove(ausgewaehlterVertrag); // löscht den ausgewählten Vertrag aus der Box
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
            string text = AnzahlTextErstellen(anzahlVertraege);
            AnzahlTextBlock.Text = text;
        }

        private string AnzahlTextErstellen(int anzahl)
        {
            if (anzahl == 1)
            {
                return $"{anzahl} Vertrag";
            }
            else
            {
                return $"{anzahl} Verträge";
            }
        }
    }
}