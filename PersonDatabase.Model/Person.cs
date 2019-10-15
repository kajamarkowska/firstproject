namespace PersonDatabase.Model
{
    // publiczna klasa reprezentująca osobę
    public class Person
    {
        private string height;

        // imię 
        public string FirstName { get; set; }
        // nazwisko
        public string LastName { get; set; }
        // wiek
        public int Age { get; set; }

        public  char Sex { get; set; }

        public int Height { get; set; }

        // konstruktor klasy Person
        public Person(string firstName, string lastName, int age, char sex, int height )
        {
            // przypisanie parametru firstName do właściwości FirstName
            FirstName = firstName;
            // przypisanie parametru lastName do właściwości LastName
            LastName = lastName;
            // przypisanie parametru age do właściwości Age
            Age = age;

            Sex = sex;

            Height = height;
        }

        public Person(string firstname, string lastname, int age, char sex, string height)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Sex = sex;
            this.height = height;
        }

        // co znaczy to ponizej?
        // przesłonięcie (nadpisanie) metody ToString (pochodzącej z klasy System.Object)
        public override string ToString()
        {
            // zwróć tekstową reprezentację obiektu, czyli wszystkie właściwości obiektu 
            // sformatowane w postaci czytelnego tekstu
            return $"{FirstName} {LastName} {Sex} {Height} => {Age} lat(a)";
        }
    }
}
