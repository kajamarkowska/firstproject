using PersonDatabase.Model;
using System;
using System.IO;


namespace ConsoleApp22
{
    public class Program
    {
        // przeanalizuj dokładnie szkielet stworzony w metodzie Main (w razie wątpliwości śmiało pytaj)
        // program możesz uruchomić i zobaczyć jak działa w tym momencie - spróbuj przetestować
        // różne możliwe scenariusze w tym podanie danych spoza zakresu [1-5] lub błędnych
        public static void Main(string[] args)
        {
            PersonCollection persons = new PersonCollection("persons.txt"); 
            bool finish = false;
            //bool deklaruje false ale czemu on zaprzecza? kazdej nieprawidlowej wartosci w metodzie?
            while (!finish)
            {
                switch (MainMenu())
                {
                    case 1:
                      

                        AddPersonMenuItem(persons);
                        break;

                    case 2:
                     

                        EditPersonMenuItem(persons);
                        break;

                    case 3:
                        DeletePersonMenuItem(persons);
                        break;

                    case 4:
                        PrintPersonsMenuItem(persons);
                        break;

                    case 5:
               
                      finish = true;
                        break;

                    default:
                        Console.WriteLine("Wybrano nieprawidłową opcję");
                        break;

                     
                }
            }
            persons.Save("persons.txt");
        }

        private static int MainMenu()
        {
            Console.WriteLine("1) Dodaj osobę");
            Console.WriteLine("2) Edytuj osobę");
            Console.WriteLine("3) Usuń osobę");
            Console.WriteLine("4) Wyświetl osoby");
            Console.WriteLine("5) Zakończ program");

            return int.Parse(Console.ReadLine());
        }

        // TODO: zaimplementuj tę metodę tak, żeby pozwalała dodać osobę
        // z poziomu konsoli powinno wyglądać to tak (przykład):
        // ----------------------------------------------------------------------------------------
        // 1) Dodaj osobę
        // 2) Edytuj osobę
        // 3) Usuń osobę
        // 4) Wyświetl osoby
        // 5) Zakończ program
        // 1
        // Podaj imię: Jan
        // Podaj nazwisko: Kowalski
        // Podaj wiek: 47
        // ----------------------------------------------------------------------------------------
        // PO TYM Jan Kowalski MAJĄCY 47 LAT POWINIEN ZOSTAĆ DODANY DO KARTOTEKI (tj. do obiektu
        // 'persons')
        private static void AddPersonMenuItem(PersonCollection persons)
        {
            Console.WriteLine("Podaj imie:");
            string name;
            name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko:");
            string surname;
            surname = Console.ReadLine();

            Console.WriteLine("Podaj wiek:");
            int age;
            age = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj płeć:");
            string sex;
            sex = Console.ReadLine();

            Console.WriteLine("Podaj wzrost:");
            int height;
            height = int.Parse(Console.ReadLine());

            Person person = new Person(name, surname, age, sex, height);
            persons.Add(person);

           


        }

        // TO ZROBIMY NA ZAJĘCIACH
        private static void EditPersonMenuItem(PersonCollection persons)
        {

                Console.WriteLine("Podaj index osoby, ktora chcesz edytowac :");
                int index;
                index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < persons.Count)

            {
                Person person = persons.GetAt(index);

                Console.WriteLine(person);
                Console.WriteLine("Podaj nowe imie:");
                
                person.FirstName = Console.ReadLine();

                Console.WriteLine("Podaj nowe nazwisko:");
                
                person.LastName = Console.ReadLine();


                Console.WriteLine("Podaj nowy wiek:");
                
                person.Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj nowa płeć:");

                person.Sex = Console.ReadLine();

                Console.WriteLine("Podaj nowy wzrost:");

                person.Height = int.Parse(Console.ReadLine());





            }

            else

            {
                Console.WriteLine("Nie ma takiego indexu");

            }
            
        }

        // TO ZROBIMY NA ZAJĘCIACH
        private static void DeletePersonMenuItem(PersonCollection persons)
        {
            Console.WriteLine("Podaj index osoby ktora chcesz usunac:");
            int index;
            index = int.Parse(Console.ReadLine());

            if( index >=0 && index<persons.Count)

            {
                Person person = persons.GetAt(index);
                Console.WriteLine($"Czy na pewno chcesz usunac osobe:{person} (t/n)?");
                if (Console.ReadLine() == "t")
                {

                    persons.Delete(index);

                    Console.WriteLine("Uzytkownik zostal prawidlowo usuniety");
                }



            }

            else

            {
                Console.WriteLine("Nie ma takiego indexu");

            }




        }

        // TODO: zaimplementuj tę metodę tak, żeby wyświetliła wszystkie osoby w kartotece (tj.
        // w obiekcie 'persons')
        private static void PrintPersonsMenuItem(PersonCollection persons)
        {
            for(int i= 0;i <persons.Count;i++)
            {
                Console.WriteLine(persons.GetAt(i));


            }
        }
    }
}