using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant // структура
        {
            private string _name; // поле с именем
            private string _surname; // поле с фамилией
            private int[] _penaltyTimes; // массив для штрафеых

            // свойства
            public string Name => _name;
            public string Surname => _surname; // сокращение get
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return null;
                    int[] coppenaltyTimes = new int[_penaltyTimes.Length];
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        coppenaltyTimes[i] = _penaltyTimes[i];
                    }
                    return coppenaltyTimes;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null) return 0;

                    return _penaltyTimes.Sum();
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null) return default;
                    for (int k = 0; k < _penaltyTimes.Length; k++)
                    {
                        if (_penaltyTimes[k] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
            }

            // методы 

            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;

                int[] penaltyTimes2 = new int[_penaltyTimes.Length + 1];
                for(int i = 0; i < penaltyTimes2.Length - 1; i++)
                {
                    penaltyTimes2[i] = _penaltyTimes[i];
                }
                penaltyTimes2[penaltyTimes2.Length - 1] = time;
                _penaltyTimes = penaltyTimes2;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                // делаем сортировку

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime) // обращаемся к элементу массива и получаем значение этого элемента в свойвстве TotalTime
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: общий штраф: {TotalTime} исключен: {IsExpelled}");
            }
        }
    }
}
