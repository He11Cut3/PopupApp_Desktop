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
    /// <summary>
    /// Логика взаимодействия для Edit_Contr.xaml
    /// </summary>
    public partial class Edit_Contr : Window
    {
        private PopupApp_dbEntities dbEntities1;
        private Contr_UC treaty1_;
        private PopupApp_Counterparty _Treaty;

        public Edit_Contr(PopupApp_dbEntities dbEntities, Contr_UC treaty_, object o)
        {
            InitializeComponent();
            dbEntities1 = dbEntities;
            treaty1_ = treaty_;
            _Treaty = (o as Button).DataContext as PopupApp_Counterparty;

            FIO.Text = _Treaty.PopupApp_Counterparty_FIO;
            Service.Text = _Treaty.PopupApp_Counterparty_Services;
            Loc.Text = _Treaty.PopupApp_Counterparty_Location;
        }

        private void New_Traty_Click(object sender, RoutedEventArgs e)
        {
            _Treaty.PopupApp_Counterparty_FIO = FIO.Text;
            _Treaty.PopupApp_Counterparty_Services = Service.Text;
            _Treaty.PopupApp_Counterparty_Location = Loc.Text;
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
