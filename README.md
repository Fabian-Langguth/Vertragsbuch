# Vertragsbuch

Die App soll zukünftig eine Übersicht über laufende Verträge, monatliche Kosten und Kündigungsfristen bieten.

## Status

Projekt in Entwicklung. Dieses Projekt ist ein Lernprojekt zur Festigung und Vertiefung meiner Fähigkeiten in C# und WPF.

## Aktuelle Funktionen

- Verträge mit Name, Anbieter, monatlichen Kosten, Vertragsbeginn (Auswahl per Kalender), Mindestlaufzeit und Kündigungsfrist zu einer Liste hinzufügen
- Verträge aus der Liste entfernen (mit Sicherheitsabfrage)
- Liste zeigt alle Angaben, Kosten als Euro-Betrag (z. B. 29,99 €) und das berechnete Datum „Kündigen bis“
- Anzeige der Anzahl der Verträge (mit Einzahl und Mehrzahl) und der Gesamtkosten pro Monat
- Prüfung auf doppelte Einträge (unabhängig von Groß- und Kleinschreibung)
- Hinweise bei falscher Eingabe: leerer Name, keine Zahl, negative Werte, Punkt statt Komma, fehlendes Datum
- Automatisches Speichern aller Verträge als JSON-Datei nach jeder Änderung
- Verständliche Fehlermeldung, falls das Speichern fehlschlägt
- 
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
- [x] Vertragsbeginn erfassen
- [x] Mindestlaufzeit und Kündigungsfrist erfassen
- [x] Kündigungsfrist anzeigen („kündigen bis“)
- [x] Gesamtkosten pro Monat anzeigen (LINQ)
- [x] Verträge als JSON-Datei speichern (mit Fehlerbehandlung)
- [ ] Verträge beim Start laden (mit Fehlerbehandlung)
- [ ] Umbau auf MVVM-Architektur
- [ ] Eingabevalidierung direkt am Eingabefeld
- [ ] Unit-Tests mit xUnit
- [ ] Einheitliches Design und Screenshots