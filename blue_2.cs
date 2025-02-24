using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class blue_2 
    {
        public struct Participant // структура
        {
            private string _name; // поле с именем
            private string _surname; // поле с фамилией
            private int[,] _marks; // oценки
            private bool[] _jumped; // массив для проверки

            // свойства
            public string Name => _name;
            public string Surname => _surname; // сокращение get
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] copmarks = new int[2, 5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            copmarks[i, j] = _marks[i, j];
                        }
                    }
                    return copmarks;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;

                    int total = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            total += _marks[i, j];
                        }
                    }
                    return total;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jumped = new bool[2]; // По два прыжка
            }

            // методы 
            public void Jump(int[] result)
            {
                if (result == null || result.Length != 5) return;
                if (_marks == null) return;

                int nojump = Array.FindIndex(_jumped, jump => !jump); // находим первый неоценённый прыжок

                
                if (nojump== -1)
                {
                    return; // все прыжки уже оценены
                }
                for (int i = 0; i < result.Length; i++)
                {
                    _marks[nojump, i] = result[i];
                }

                _jumped[nojump] = true; // прыжок оценённый
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                // делаем сортировку

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalScore > array[j].TotalScore) // обращаемся к элементу массива и получаем значение этого элемента в свойвстве TotalScore
                        {
                            (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        }
                    }
                }
            }

            // метод принт
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} балл: {TotalScore}");
            }
        }


    }
}
