namespace PersonDatabase.Model
{
    // publiczna klasa reprezentująca osobę
    public class Person
    {
        // imię 
        public string FirstName { get; }
        // nazwisko
        public string LastName { get; }
        // wiek
        public int Age { get; }

        // konstruktor klasy Person
        public Person(string firstName, string lastName, int age)
        {
            // przypisanie parametru firstName do właściwości FirstName
            FirstName = firstName;
            // przypisanie parametru lastName do właściwości LastName
            LastName = lastName;
            // przypisanie parametru age do właściwości Age
            Age = age;
        }
        // co znaczy to ponizej?
        // przesłonięcie (nadpisanie) metody ToString (pochodzącej z klasy System.Object)
        public override string ToString()
        {
            // zwróć tekstową reprezentację obiektu, czyli wszystkie właściwości obiektu 
            // sformatowane w postaci czytelnego tekstu
            return $"{FirstName} {LastName} => {Age} lat(a)";
        }
    }
}
