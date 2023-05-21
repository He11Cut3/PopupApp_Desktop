using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Windows.Shapes;

namespace PopupApp.Treaty
{

    public partial class Edit_Treaty : Window
    {
        private PopupApp_dbEntities dbEntities1;
        private Treaty_UC treaty1_;
        private PopupApp_Treaty _Treaty;

        public Edit_Treaty(PopupApp_dbEntities dbEntities, Treaty_UC treaty_, object o)
        {
            InitializeComponent();
            dbEntities1 = dbEntities;
            treaty1_ = treaty_;
            _Treaty = (o as Button).DataContext as PopupApp_Treaty;

            Name.Text = _Treaty.PopupApp_Treaty_Name;
            Location.Text = _Treaty.PopupApp_Treaty_Location;
            Number.Text = _Treaty.PopupApp_Treaty_Number_Treaty;
            Date_Start.Text = _Treaty.PopupApp_Treaty_Start_Date;
            Date_End.Text = _Treaty.PopupApp_Treaty_End_Date;
            Contr.Text = _Treaty.PopupApp_Treaty_Counterparty;
            myComboBox.Text = _Treaty.PopupApp_Treaty_Coming;
            Service.Text = _Treaty.PopupApp_Treaty_Services;
            Cost.Text = _Treaty.PopupApp_Treaty_Cost;
            myComboBox1.Text = _Treaty.PopupApp_Treaty_Status;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _Treaty.PopupApp_Treaty_Name = Name.Text;
            _Treaty.PopupApp_Treaty_Location = Location.Text;
            _Treaty.PopupApp_Treaty_Services = Service.Text;
            _Treaty.PopupApp_Treaty_Start_Date = Date_Start.SelectedDate?.ToString("dd.MM.yyyy");
            _Treaty.PopupApp_Treaty_End_Date = Date_End.SelectedDate?.ToString("dd.MM.yyyy");
            _Treaty.PopupApp_Treaty_Number_Treaty = Number.Text;
            _Treaty.PopupApp_Treaty_Coming = (myComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            _Treaty.PopupApp_Treaty_Counterparty = Contr.Text;
            _Treaty.PopupApp_Treaty_Cost = Cost.Text;
            _Treaty.PopupApp_Treaty_Status = (myComboBox1.SelectedItem as ComboBoxItem)?.Content?.ToString();
            dbEntities1.SaveChanges();
            treaty1_.Pop_Up();
            this.Close();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
