using System.Windows;
using T_Komp_zadanie.View_Model;

namespace T_Komp_zadanie.View
{
    /// <summary>
    /// Logika interakcji dla klasy Database_View.xaml
    /// </summary>
    public partial class Database_View : Window
    {
        public Database_View()
        {
            InitializeComponent();
            this.DataContext = new Database_View_Model(); //Powiązanie view z view model
        }

    }
}