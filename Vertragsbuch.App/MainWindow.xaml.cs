using System.ComponentModel;
using System.Globalization;
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
            GesamtkostenAktualisieren();
           
           
        }

        private void HinzufuegenButton_Click(object sender, RoutedEventArgs e)
        {
            var vertragsName = VertragsNameTextBox.Text.Trim(); // Entfernt Leerzeichen
            var istZahl = decimal.TryParse(KostenTextBox.Text, CultureInfo.GetCultureInfo("de-DE"), out decimal vertragsKosten);
            var istMindestlaufzeitZahl = int.TryParse(MindestlaufzeitTextBox.Text, out int mindestlaufzeitMonate);
            var istKuendigungsfristZahl = int.TryParse(KuendigungsfristTextBox.Text, out int kuendigungsfristMonate); // GEÄNDERT: Name mit "s"
            DateTime? vertragsbeginn = VertragsbeginnDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(vertragsName)) // Prüft ob Eingabe leer ist
            {
                MessageBox.Show("Das Feld darf nicht leer sein.");
            }
            else if (!istZahl) // Prüft ob Kosten eine Zahl sind
            {
                MessageBox.Show("Bitte eine Zahl eingeben.");
            }
            else if (KostenTextBox.Text.Contains("."))
            {
                MessageBox.Show("Bitte ein Komma statt eines Punktes verwenden.");
            }
            else if (vertragsKosten < 0) // Prüft ob Kosten negativ sind
            {
                MessageBox.Show("Die Zahl darf nicht negativ sein.");
            }
            else if (vertragsbeginn == null)
            {
                MessageBox.Show("Bitte ein Datum auswählen.");
            }
            else if (!istMindestlaufzeitZahl)
            {
                MessageBox.Show("Bitte bei der Mindestlaufzeit eine ganze Zahl eingeben.");
            }
            else if (mindestlaufzeitMonate < 0)
            {
                MessageBox.Show("Die Mindestlaufzeit darf nicht negativ sein.");
            }
            else if (!istKuendigungsfristZahl) // GEÄNDERT: prüft jetzt die Kündigungsfrist
            {
                MessageBox.Show("Bitte bei der Kündigungsfrist eine ganze Zahl eingeben.");
            }
            else if (kuendigungsfristMonate < 0)
            {
                MessageBox.Show("Die Kündigungsfrist darf nicht negativ sein.");
            }
            else if (IstVertragVorhanden(vertragsName)) // Prüft ob Vertrag schon existiert
            {
                MessageBox.Show("Der Vertrag ist schon vorhanden.");
            }
            else // Fügt Vertrag hinzu
            {
                var vertrag = new Vertrag()
                {
                    Name = vertragsName,
                    Anbieter = AnbieterTextBox.Text.Trim(),
                    MonatlicheKosten = vertragsKosten,
                    Vertragsbeginn = vertragsbeginn.Value,
                    MindestlaufzeitMonate = mindestlaufzeitMonate,
                    KuendigungsfristMonate = kuendigungsfristMonate
                };

                VertragsListBox.Items.Add(vertrag);
                VertragsNameTextBox.Clear();
                AnbieterTextBox.Clear();
                KostenTextBox.Clear();
                VertragsbeginnDatePicker.SelectedDate = null;
                MindestlaufzeitTextBox.Clear();
                KuendigungsfristTextBox.Clear();
                AnzahlAktualisieren();
                GesamtkostenAktualisieren();
             
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
                    GesamtkostenAktualisieren();
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

        private void GesamtkostenAktualisieren() // Zeigt aktuelle Gesamtkosten im Fenster an
        {
            decimal gesamtkosten = GesamtkostenBerechnen(); // Summe holen
            string kostenText = gesamtkosten.ToString("C", CultureInfo.GetCultureInfo("de-DE")); // Währungsfromat Deutsch
            GesamtkostenTextBlock.Text = $"{kostenText} pro Monat"; // Text ins Fenster schreiben
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

        private decimal GesamtkostenBerechnen() // Berechnet die Summe der monatlichen Kosten aller Verträge
        {
            decimal gesamtkosten = VertragsListBox.Items // alle Einträge der ListBox
                .Cast<Vertrag>() // jeden Eintrag als Vertrag behandeln
                .Sum(vertrag => vertrag.MonatlicheKosten); // Monatskosten addieren
            return gesamtkosten;
        }
    }
}