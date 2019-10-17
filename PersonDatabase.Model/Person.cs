namespace PersonDatabase.Model
{
    // publiczna klasa reprezentująca osobę
    public class Person
    {
       

        // imię 
        public string FirstName { get; set; }
        // nazwisko
        public string LastName { get; set; }
        // wiek
        public int Age { get; set; }

        public  string Sex { get; set; }

        public int Height { get; set; }

        public int Id { get; set; }

        public Person()
        {
            

        }

        // konstruktor klasy Person
        public Person(string firstName, string lastName, int age, string sex, int height )
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
