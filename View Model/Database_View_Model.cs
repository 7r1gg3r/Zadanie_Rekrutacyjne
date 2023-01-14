using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using T_Komp_zadanie.Model;

namespace T_Komp_zadanie.View_Model
{
    public class Database_View_Model 
    {
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand //komenda do której bindujemy przycisk
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }
        public Database_View_Model()
        {
            ButtonCommand = new RelayCommand(new Action<object>(_LoginButtonClick));
        }
        private void _LoginButtonClick(object sender)
        {
           
        }
    }
}