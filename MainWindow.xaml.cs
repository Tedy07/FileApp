using System;
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
using Path = System.IO.Path;

namespace FileApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var fileName = tbFileName.Text;
            // pobieranie warości z okienka textBox tbFileName

            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Podaj nazwe pliku");
                return;
            }
            //sprawdzenie czy zostało cokolwiek wpisane w 

            //ścieżka
            //var path = "SampleFile.txt";
            var binPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //ta konstrukcja dostosowuje ścieżkę do danej sytuacji

            var expectedDirectory = Path.Combine(binPath, "myFiles21");
            // w tym miejscu tworzony jest katalog myFiles2 ze ścieżką do pliku
            //binPath + "\\" + "myfiles";

            //ścieżka do myFiles

            if (!Directory.Exists(expectedDirectory))
                Directory.CreateDirectory(expectedDirectory);

            //warunek sprawdza czy dany katalog nie istnieje (jest !) jeżeli nie istnieje to go tworzy
            // nazwa katalogu, który tworzy expectedDirectory

            var path = Path.Combine(expectedDirectory, fileName);
            //tworzony jest plik SampleFile2new lub wartosc zmiennej fileName


            using (FileStream fileStream = File.Create(path))
            {
                //var text1 = "123321";
                var text = rtbContent.Text; 
                // tu skończono minuta w filmie 16:27

                var content = Encoding.UTF8.GetBytes(text);
                //przygotowanie bytów z tego streenga text

                fileStream.Write(content, 0, content.Length);

            }
            // chcąc tworzyć nowy plik FileStrim o nazwiw fileStrim
            // fileStrim musi mieć argumenty jako byte
        }


    }
}
