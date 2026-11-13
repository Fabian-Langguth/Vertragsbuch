# Vertragsbuch

Die App soll zukünftig eine Übersicht über laufende Verträge, monatliche Kosten und Kündigungsfristen bieten.

## Status

Projekt in Entwicklung. Dieses Projekt ist ein Lernprojekt zur Festigung und Vertiefung meiner Fähigkeiten in C# und WPF.

## Aktuelle Funktionen

- Verträge mit Name, Anbieter und monatlichen Kosten zu einer Liste hinzufügen
- Verträge aus der Liste entfernen
- Liste zeigt Name, Anbieter und Kosten als Euro-Betrag (z. B. 29,99 €)
- Prüfung auf doppelte Einträge (unabhängig von Groß- und Kleinschreibung)
- Hinweise bei falscher Eingabe: leerer Name, keine Zahl, negative Kosten, Punkt statt Komma
- Anzeige der Anzahl der Verträge (mit Einzahl und Mehrzahl)

## Technologien

- C#
- WPF (XAML)
- .NET 10
- Visual Studio 2026
- Git/GitHub

## Roadmap

- [x] Verträge hinzufügen und entfernen
- [x] Doppelte Verträge verhindern
- [x] Anzahl der Verträge anzeigen
- [x] Eigene Klasse `Vertrag` mit Name, Anbieter und monatlichen Kosten
- [x] Liste zeigt Name, Anbieter und Kosten (Euro-Format)
- [x] Einfache Eingabeprüfung im Formular
- [ ] Vertragsbeginn und Kündigungsfrist erfassen
- [ ] Kündigungsfrist anzeigen („kündigen bis")
- [ ] Monatliche Gesamtkosten berechnen
- [ ] Dauerhafte Speicherung (JSON)
- [ ] Fehlerbehandlung beim Laden und Speichern
- [ ] Umbau auf MVVM-Architektur
- [ ] Eingabevalidierung direkt am Eingabefeld
- [ ] Unit-Tests mit xUnit
- [ ] Einheitliches Design und Screenshots