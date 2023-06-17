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

namespace PopupApp.Treaty
{
    /// <summary>
    /// Логика взаимодействия для Contr_UC.xaml
    /// </summary>
    public partial class Contr_UC : UserControl
    {
        PopupApp_dbEntities popupApp_DbEntities = new PopupApp_dbEntities();
        List<PopupApp_Counterparty> popupApp_Treaties = new List<PopupApp_Counterparty>();

        public Contr_UC()
        {
            InitializeComponent();
            listView.ItemsSource = popupApp_DbEntities.PopupApp_Counterparty.OrderBy(A => A.PopupApp_Counterparty_id).ToList();
        }

        public void Pop_Up()
        {
            popupApp_Treaties = popupApp_DbEntities.PopupApp_Counterparty.ToList();
            listView.ItemsSource = popupApp_Treaties;
        }

        private void New_Contr_Click(object sender, RoutedEventArgs e)
        {
            Add_Contr add_Treaty = new Add_Contr(popupApp_DbEntities, this);
            add_Treaty.ShowDialog();
        }

        private void Find_Inf_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = Find_Inf.Text;
            var query = from emp in popupApp_DbEntities.PopupApp_Counterparty
                        where emp.PopupApp_Counterparty_FIO.Contains(searchText) || emp.PopupApp_Counterparty_Services.Contains(searchText) || emp.PopupApp_Counterparty_Location.Contains(searchText)
                        select emp;

            listView.ItemsSource = query.ToList();
        }

        private void Edit_Treaty_Click(object sender, RoutedEventArgs e)
        {
            Edit_Contr edit_Treaty = new Edit_Contr(popupApp_DbEntities, this, sender);
            edit_Treaty.ShowDialog();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var item = button.DataContext as PopupApp_Counterparty;
            popupApp_DbEntities.PopupApp_Counterparty.Remove(item);
            popupApp_DbEntities.SaveChanges();
            Pop_Up();
        }

        
    }
}

