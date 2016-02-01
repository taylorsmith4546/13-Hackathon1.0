using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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


namespace NeflixRoulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBoxDirectorName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxKeyWord_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxYear_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxActorName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonSpin_Click(object sender, RoutedEventArgs e)
        {
            string director = textBoxDirectorName.Text;
            string title = textBoxTitle.Text;
            int year;
            int.TryParse(textBoxYear.Text, out year);
            string actor = textBoxActorName.Text;


            var service = new NetflixRoulette.Core.NetflixRoulette();

            var movie = service.GetData(title, year, actor, director);

            foreach (PropertyInfo pi in movie.GetType().GetProperties())
            //MessageBox.Show(movie.show_title);
            {
                    MessageBox.Show(pi.Name + ": " + pi.GetValue(movie));
                             }
                         Console.Read();





        }
    }
}
