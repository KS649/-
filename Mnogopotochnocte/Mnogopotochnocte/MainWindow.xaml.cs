using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;
using Path = System.IO.Path;

namespace Mnogopotochnocte
{


    public partial class MainWindow : Window
    {
        FileGet fileGet = new FileGet();
        public MainWindow()
        {
            InitializeComponent();
           
            ListV.ItemsSource = fileGet.DirectoryGet();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = ListV.SelectedItem as string;
                if (path.Contains("."))
                {
                    fileGet.OpenFile(path);
                }
                else 
                {
                    fileGet.ChangePath(path);
                    ListV.SelectedItem = null;
                    ListV.SelectedItem = fileGet.DirectoryGet();
                }
               
            }
            finally 
            {
            
            }
            


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {       
            string path = @"C:\\";
            try
            {               
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }              
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

               
                di.Delete();
                Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception z)
            {
                Console.WriteLine("The process failed: {0}", z.ToString());
            }
            finally { }
        }
        private void Button_Click_2(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss");
            string papka = Path.Combine(Directory.GetCurrentDirectory(), "Антипаблик  " + time);
            string text = "Тест текст";
            Directory.CreateDirectory("Тестовая директория  " + time);

            string papka1 = Path.Combine(Directory.GetCurrentDirectory(), "Тестовая директория  " + time);
            string file = Path.Combine(papka1, "file.txt");

            if (!Directory.Exists(papka1))
                Directory.CreateDirectory(papka1);
            File.WriteAllText(file, text);
        }
    }
    public class FileGet
    {
        private string _directory = @"C:\\";
        private List<string> _filesList = new List<string>();
        public void ChangePath(string path)
        {
            _directory = path;

        }
        public List<string> DirectoryGet()
        {
            _filesList.Clear();
            if (Directory.Exists(_directory))
            {
                string[] mass=Directory.GetDirectories(_directory);
                foreach (string file in mass) 
                {
                _filesList.Add(file);

                }
                string[] mass1 = Directory.GetFiles(_directory);
                foreach (string file in mass1)
                {
                    _filesList.Add(file);
                }
            }
            return _filesList;
        }
        public void OpenFile(string path)
        {
            System.Diagnostics.Process.Start(path);
        }
    }




}
