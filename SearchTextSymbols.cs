using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SymbolsOfStrings
{
    class SearchTextSymbols
    {
        private string[] _strs_input = new string[100]; // набор строк
        private int _index = 0; // индекс строки в наборе строк
        public void Clear_Strings() // метод очистки строк
        {
            for (int i = 0; i < 100; i++)
            {
                _strs_input[i] = "";
            }
            Start_Enumeration();
        }
        public void Start_Enumeration() // метод начала перебора
        {
            _index = 0; // сбрасываем индекс начала перебора строк на ноль
        }
        public string Get_Next_String() // метод получение очередной строки
        { // перед вызовом внутренний индекс НЕОБХОДИМО обнулить!!!
            string str_ret = null;
            for (int i = _index; i < 100; i++) // перебираем строки, начиная с _index
            {
                str_ret = _strs_input[i];
                if (str_ret != null) // если строка непустая, возвращаем ее
                {
                    _index = i + 1; // обновляем индекс последней считанной строки на следующую
                    break; // выходим из цикла
                }
            }
            return str_ret; // возвращаем найденную строку
        }
        public void LoadStrings(ref string[] strs)
        {
            Clear_Strings();
            int count = strs.Count(); // число передаваемых для копирования строк
            if (count > 100) count = 100; // ограничиваем число строк до 100
            for (int i = 0; i < count; i++)
            {
                _strs_input[i] = strs[i]; // копируем каждую строку в строки внутри данного класса
            }
        }
        public int Search_Num_Of_Letter(char letter) // поиск символа в наборе строк 
        {
            int find_count = 0; // число совпадений
            Start_Enumeration(); // зануляем внутренний индекс
            for (int i = 0; i < 100; i++)
            {
                string str = Get_Next_String(); // получаем очередную строку
                if (str != null) // если строка непустая
                {
                    int len = str.Length; // длина очередной строки
                    for (int i_len = 0; i_len < len; i_len++)
                    {
                         if (str[1] == letter) // сравниваем со второй по счету буквой
                        {
                            find_count++; // увеличиваем число совпадений на 1, если коды символов одинаковы
                        }
                    }
                }
                else // иначе прекращаем поиск
                {
                    break; // выход из цикла
                }
            }
            return find_count; // возвращаем найденное количество символов
        }
    }
}
