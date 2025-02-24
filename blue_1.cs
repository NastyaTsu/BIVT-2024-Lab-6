using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class blue_1
    {
        public struct Response // структура
        {
            private string _name; // поле с именем
            private string _surname; // поле с фамилией
            private int _votes; // голоса

            // свойства
            public string Name { get { return _name; } }
            public string Surname => _surname; // сокращение get
            public int Votes => _votes;

            // конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;            }

            // методы 
            public int CountVotes(Response[] responses)
            {
                if (responses == null || responses.Length == 0) return 0;
                _votes = 0;
                foreach (var i in responses)
                {
                    // имя и фамилия совпадают с текущим кандидатом увеличиваем
                    if (i.Name == _name && i.Surname == _surname)
                    {
                        _votes++;
                    }
                }
                return _votes;  //общее количество голосов
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_votes} голосов");
            }
        }
    }
}
