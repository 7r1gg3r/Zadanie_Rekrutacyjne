using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using T_Komp_zadanie.Model;

namespace T_Komp_zadanie.View_Model
{
    public class Database_View_Model : BasicViewModel
    {
        //Deklaracja podstawowych wartości
        private string connectionString;
        private ICommand _CheckCommand;
        public ICommand CheckCommand 
        {
            get
            {
                return _CheckCommand;
            }
            set
            {
                _CheckCommand = value;
            }
        }
        private ICommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                return _LoadCommand;
            }
            set
            {
                _LoadCommand = value;
            }
        }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get 
            { 
                return _isEnabled;
            }
            private set
            {
                _isEnabled = value;
                OnPropertyChanged(() => IsEnabled); 
            }
        }
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value; 
            }
        }
        private ObservableCollection<DataModel> _ItemList;
        public ObservableCollection<DataModel> ItemList
        {
            get
            {
                return _ItemList;
            }
            set
            { 
                _ItemList = value; 
                OnPropertyChanged(() => ItemList); 
            }
        }
        private string _password;

        public Database_View_Model() //Konstruktor inicjalizujący zmienne
        {
            connectionString = "Data Source=DESKTOP-MHAAA0H\\TEW_SQLEXPRESS;Initial Catalog=DevData;"; //Nazwa serwera i bazy danych, z którymi się łączymy
            IsEnabled = false;
            ItemList = new ObservableCollection<DataModel>();
            LoadCommand = new RelayCommand(new Action<object>(_LoadCommandCLick));
            CheckCommand = new RelayCommand(new Action<object>(_CheckCommandClick));
        }
        private void _CheckCommandClick(object sender) //Sprawdzenie hasła - jeśli jest poprawne, następuje zmiana wartości IsEnabled na True
        {
            var pass = (PasswordBox)sender;
            if (CheckConnection(pass.Password))
            {
                IsEnabled=true;
            }
        }
        private void _LoadCommandCLick(object sender) //Zbieranie danych z serwera SQL
        {
            LoadDataFromSQL();
        }
        public bool CheckConnection(string password) //Sprawdzanie połączenia przy udanej próbie logowania
        {
            string conString = $"{connectionString}User ID={Login};Password={password};";
            bool isValid = false;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(conString);
                con.Open();
                isValid = true;
                _password = password;
            }
            catch (SqlException ex)
            {
                isValid = false;
                MessageBox.Show("Połączenie nieudane!\n" + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Połączenie udane!");
                }
                con.Close();    
            }

            return isValid;
        }
        public void LoadDataFromSQL() //pobieranie danych z serwera, spisywanie kolumn z typem Int w tabeli datagrid
        {
            DataTable results = new DataTable();
            string conString = $"{connectionString}User ID={Login};Password={_password};";
            using (SqlConnection con = new SqlConnection(conString)) //używamy using bo zawiera interfejs IDisposable
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("select c.name as column_name from sys.columns c join sys.tables t on t.object_id = c.object_id where type_name(user_type_id) = 'int' order by c.column_id;", con))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(results);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
           
            if (ItemList.Count> 0) ItemList.Clear();
            if(results.Rows.Count > 0)
            foreach (DataRow row in results.Rows) 
            {
               ItemList.Add(new DataModel(row.ItemArray[0].ToString()));
            }
            
        }
    }
}