using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CatArray
{
    internal class Program
    {
        public class Cat
        {
            private string name;

            private int age;

            private string color;

            public override string ToString()
            {
                return $"{GetName()}, {GetAge()}, {GetColor()}";

                return base.ToString();
            }
            public string GetName()
            {
                return name;
            }

            public int GetAge()
            {
                return age;
            }

            public string GetColor()
            {
                return color;
            }

            public Cat(string name, int age, string color)
            {
                this.name = name;

                this.age = age;

                this.color = color;
            }
        }

        public class CatHouse
        {
            Cat[] cats = new Cat[6];

            private int count = 0;

            public void Add(Cat cat)
            {
                if (cats.Length == count)
                {
                    resizeFunction();
                }

                cats[count] = cat;

                count++;
            }

            public override string ToString()
            {
                string myString = "";

                for (int i = 0; i < count; i++)
                {
                    string catInfo = cats[i].ToString();

                    string ret = "";

                    catInfo += ret + '\n';

                    myString += catInfo;
                }

                return myString;
            }

            public void resizeFunction()
            {
                Cat[] cats2 = new Cat[cats.Length * 2];

                for (int i = 0; i < cats.Length; i++)
                {
                    cats2[i] = cats[i];
                }

                cats = cats2;
            }

            public bool removeCats(string catName = "")
            {
                int index = -1;

                for (int i = 0; i < cats.Length; i++)
                {
                    if (catName == cats[i].GetName())
                    {
                        index = i;
                    }
                }

                if (index == -1)
                {
                    return false;
                }

                for (int i = index; i < cats.Length - 1; i++)
                {
                    cats[i] = cats[i + 1];

                }

                count--;

                return true;

            }

            public int findIndex(string catName)
            {
                for (int i = 0; i < cats.Length; i++)
                {
                    if (catName == cats[i].GetName())
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void showSpecificCat(string catName)
            {
                int index = findIndex(catName);
               
                if(index != -1)
                {
                    Console.WriteLine(cats[index]);
                }
                else
                {
                    Console.WriteLine("Cat Does Not Exist.");
                }
            }
        }

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            //create array of cats. cat will have name, age, color.
            //make another class called cathouse.
            //will be able to hold on to a array of cats. 
            //make 5 individual cats and add them to the cathouse.

            //be able to add and remove cats from cathouse.
            //be able to view cats in cathouse. if you give a name, it will give you back a cat.

            bool isRunning = true;

            while (isRunning == true)
            {
                CatHouse catHouse = new CatHouse();

                Cat fluffy = new Cat("fluffy", 3, "white");
                Cat oreo = new Cat("oreo", 4, "black and white");
                Cat tubby = new Cat("tubby", 2, "black");
                Cat munchkin = new Cat("munchin", 5, "orange");
                Cat chub = new Cat("chub", 1, "grey");


                catHouse.Add(fluffy);
                catHouse.Add(oreo);
                catHouse.Add(tubby);
                catHouse.Add(munchkin);
                catHouse.Add(chub);

                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine(fluffy.ToString());
                Console.WriteLine(oreo.ToString());
                Console.WriteLine(tubby.ToString());
                Console.WriteLine(munchkin.ToString());
                Console.WriteLine(chub.ToString());


                Console.WriteLine("What Name Is Your Cat?");
                string string1 = Console.ReadLine();

                Console.WriteLine("What Age Is Your Cat?");
                string string2 = Console.ReadLine();

                int catAge = 0;

                catAge = int.Parse(string2);

                Console.WriteLine("What Color Is Your Cat");
                string string3 = Console.ReadLine();

                Cat cat1 = new Cat($"{string1}", catAge, $"{string3}");

                catHouse.Add(cat1);

                Console.WriteLine(catHouse);

                Console.WriteLine("Do You Want To Take A Cat Out?");
                string string4 = Console.ReadLine();

                if (string4 == "yes")
                {
                    Console.WriteLine("What Cat Do You Want To Take Out?");
                    string string5 = Console.ReadLine();

                    if (catHouse.removeCats(string5) == true)
                    {
                        Console.WriteLine(catHouse);
                    }
                }
                else if (string4 == "no")
                {
                    break;
                }

                Console.WriteLine("Do You Want To Know About A Specific Cat?");
                string string6 = Console.ReadLine();

                if (string6 == "yes")
                {
                    Console.WriteLine("What Cat Do You Want To Know About?");
                    string string7 = Console.ReadLine();

                    catHouse.showSpecificCat(string7);
                }
                else if (string6 == "no")
                {
                    break;
                }
            }
        }
    }
}