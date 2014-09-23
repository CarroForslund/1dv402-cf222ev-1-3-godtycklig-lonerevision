using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_godtycklig_lonerevision_a
{
    class Program
    {
        static void Main(string[] args)
        {
            //Anropa ReadInt(); för att läsa in antal löner
            //Om antalet löner är lika med eller större än 2, gå vidare och anropa ProcessSalaries();
            //Annars skrivs felmeddelande ut
            //Avsluta program med ESC och gå vidare med valfri tangent
            int numberOfSalaries;

            while (true)
            {
                numberOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if (numberOfSalaries >= 2)
                {
                    break;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste mata in minst två löner för att det ska fungera.");
                    Console.ResetColor();

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tryck på valfri tangent för att göra en ny beräkning - ESC avslutar");
                    Console.ResetColor();
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    else if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    {
                        //Är det verkligen ok att ha en tom else-kropp?
                    }
                }
            }

            ProcessSalaries(numberOfSalaries);
        }

        static void ProcessSalaries(int count)
        {
            //Läs in lönerna till en lokal array av typen int[]
            //Kopiera och sortera array
            //Beräkna median, meddellön och lönespridning och presentera resultat som valuta
            //Lista lönerna tre på varje rad i den ordning de matats in (använd %) och högerjustera
            int[] salaries = new int[count];
            int[] salariesCopy = new int[count];
            int lowestSalary;
            int highestSalary;
            int spread;
            int median;
            int rightOfMiddle;
            int leftOfMiddle;

            for (int i = 0; i < count; i++)
            {
                String s = String.Format("Ange lön nr {0}: ", i + 1);
                salaries[i] = ReadInt(s);
                //salaries[i] = ReadInt("Ange lön nr x:");
                //Console.Write("Ange lön nr {0}:", i + 1);
            }

            Array.Copy(salaries, salariesCopy, count);
            Array.Sort(salaries);

            Console.WriteLine("------------------------------------------------");
            //Medianlön
            if (salaries.Length % 2 != 0)
            {
                Console.WriteLine("Medianlön\t: {0, 10:c0}", salaries[count / 2]); 
            }
            else
            {
                rightOfMiddle = salaries[count / 2];
                leftOfMiddle = salaries[count / 2 - 1];
                median = (rightOfMiddle + leftOfMiddle) / 2;

                Console.WriteLine("Medianlön\t: {0, 10:c0}", median);
            }

            //Meddellön
            Console.WriteLine("Meddellön\t: {0, 10:c0}", salaries.Average());

            //Lönespridning
            lowestSalary = salaries.First();
            highestSalary = salaries.Last();
            spread = highestSalary - lowestSalary;

            Console.WriteLine("Lönespridning\t: {0, 10:c0}", spread);
            Console.WriteLine("------------------------------------------------");

            //3 kolumner med löner i inmatad ordning
            for (int salary = 0; salary < count; salary++)
            {
                
                Console.Write("{0, 10}", salariesCopy[salary]);
                switch (salary % 3)
                {
                    case 0:
                        Console.Write("\t");
                        break;
                    case 1:
                        Console.Write("\t");
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }

        static int ReadInt(string prompt)
        {
            //Metod för att läsa in heltal
            //Skriv ut felmeddelande om värdet inte kan tolkas som ett heltal
            int input;

            while (true)
            {
                Console.Write(prompt);
                try
                {
                    input = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste mata in ett heltal med siffertangenterna");
                    Console.ResetColor();
                } 
            }
            return input;
        }
    }
}
