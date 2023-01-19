using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Input;

namespace T_Komp_zadanie.View_Model 
    /*Podstawowy widok, po którym inne będą dziedziczyć.
    *Implementuje interfejs INotifyPropertyChanged wykrywający zmianę bindowanych pól.*/
{
    public class BasicViewModel : INotifyPropertyChanged
    {
        #region Propertychanged

        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}