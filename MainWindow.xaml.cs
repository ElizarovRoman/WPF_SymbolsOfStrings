using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using SearchTextSymbols = WPF_SymbolsOfStrings.SearchTextSymbols;
using Microsoft.Win32;

namespace WPF_SymbolsOfStrings
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SearchTextSymbols _searchTextSymbols = new SearchTextSymbols();
        public MainWindow()
        {
            InitializeComponent();
            ArrayList arr_list = new ArrayList();
            arr_list.AddRange(listBox_Input.Items);
            string[] strs = arr_list.ToArray(typeof(string)) as string[];
            _searchTextSymbols.LoadStrings(ref strs);
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            _searchTextSymbols.Clear_Strings();
            listBox_Input.Items.Clear();
            toolStripStatusLabel.Text = "Выполнена очистка строк!";
        }

        private void button_FindLetter_Click(object sender, RoutedEventArgs e)
        {
            char ch_letter = textBox_Letter.Text[0];
            int count_letter = _searchTextSymbols.Search_Num_Of_Letter(ch_letter);
            string str = "Символ " + ch_letter.ToString() + " встречается в тексте " +
               count_letter.ToString() + " раз!";
            toolStripStatusLabel.Text = str;
        }

        private void button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string file_name = openFileDialog.FileName;
                listBox_Input.Items.Clear();
                using (StreamReader r = new StreamReader(file_name, Encoding.Default))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBox_Input.Items.Add(line);
                    }
                }
                ArrayList arr_list = new ArrayList();
                arr_list.AddRange(listBox_Input.Items);
                string[] strs = arr_list.ToArray(typeof(string)) as string[];
                _searchTextSymbols.LoadStrings(ref strs);     
            }
        }

        private void ToolStripMenu_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Елизаров Роман", "О программе",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
