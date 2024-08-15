---

# MyArrayList Projekt

Dies ist ein .NET C# Projekt, das eine generische `MyArrayList<T>` implementiert. Die Liste unterstützt grundlegende Funktionen wie `Add`, `Delete` und `Count`. Zudem sind Unit-Tests für diese Funktionen implementiert.

## Funktionen der `MyArrayList<T>`

Die `MyArrayList<T>` bietet aktuell folgende Funktionen:

1. **Add(T item)**: Fügt ein Element zur Liste hinzu.
2. **Delete(T item)**: Entfernt ein Element aus der Liste.
3. **Count**: Gibt die Anzahl der Elemente in der Liste zurück.


## Unit Tests

Die Unit-Tests für dieses Projekt wurden mit **xUnit** erstellt. Die Tests decken die aktuellen Funktionen ab und überprüfen:

- Das Hinzufügen von Elementen (`Add`).
- Das Löschen von Elementen (`Delete`).
- Die korrekte Ermittlung der Anzahl (`Count`).

### Tests ausführen

Stelle sicher, dass du .NET installiert hast. Um die Tests auszuführen, navigiere zum Projektverzeichnis und führe den folgenden Befehl aus:

```bash
dotnet test
```

## Installation und Verwendung

1. **Projekt klonen**:

```bash
git clone https://github.com/dein-benutzername/MyArrayListProjekt.git
```

2. **Zum Projektverzeichnis wechseln**:

```bash
cd MyArrayListProjekt
```

3. **Projekt bauen**:

```bash
dotnet build
```

4. **Unit-Tests ausführen**:

```bash
dotnet test
```

## Mitwirken

Dieses Projekt wurde in Zusammenarbeit mit <a href="https://github.com/Felix-dev-hub" target="_blank">@Felix</a> erstellt.

### Nächste Schritte

- Implementierung der geplanten Funktionen.
- Erweiterung der Tests für neue Features.
- Verbesserung der Performance der Liste.

---

Viel Erfolg mit deinem Projekt!
