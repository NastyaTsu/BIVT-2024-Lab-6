using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.blue_4;

namespace Lab_6
{
    public class blue_4
    {
        public struct Team // структура
        {
            private string _name;
            private int[] _scores;

            // свойства
            public string Name => _name;
            public int[] Scores => _scores;
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;

                    return _scores.Sum();
                }
            }


            // конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            // методы 

            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] t = new int[_scores.Length + 1];
                for(int i = 0; i < _scores.Length; i++)
                {
                    t[i] = _scores[i];
                }
                t[t.Length - 1] = result;
                _scores = t;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _index; //индекс команды

            // свойства
            public string Name => _name;
            public Team[] Teams => _teams;

            // конструктор

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _index = 0;
            }

            //методы

            public void Add(Team team) 
            {
                if (_teams == null) return;

                if (_index < _teams.Length)
                {
                    _teams[_index] = team;
                    _index++;
                }
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || teams.Length == 0 || teams == null) return;

                foreach (var team in teams)
                {
                    Add(team);
                }
            }
            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;
                // делаем сортировку


                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group resultat = new Group("финалисты");
                int i = 0, k = 0, h = 0, j = 0;
                while (i < size && j < size)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        resultat.Add(group1.Teams[i]);
                        i++;
                    }
                    else
                    {
                        resultat.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while (k < size)
                {
                    resultat.Add(group1.Teams[k]);
                    k++;
                }
                while (h < size)
                {
                    resultat.Add(group2.Teams[h]);
                    h++;
                }
                return resultat;
            }

            public void Print()
            {
                Console.WriteLine(_name);

                foreach(Team i in _teams)
                {
                    i.Print();
                }
                    
                Console.WriteLine();
            }
        }
    }
}
