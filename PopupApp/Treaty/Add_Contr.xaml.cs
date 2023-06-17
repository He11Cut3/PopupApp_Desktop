using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Windows.Shapes;

namespace PopupApp.Treaty
{
    /// <summary>
    /// Логика взаимодействия для Add_Contr.xaml
    /// </summary>
    public partial class Add_Contr : Window
    {
        private PopupApp_dbEntities dbEntities;
        private Contr_UC treaty_;

        public Add_Contr(PopupApp_dbEntities dbEntities, Contr_UC treaty_)
        {
            InitializeComponent();
            this.dbEntities = dbEntities;
            this.treaty_ = treaty_;
        }

        private void New_Traty_Click(object sender, RoutedEventArgs e)
        {
                dbEntities.PopupApp_Counterparty.Add(new PopupApp_Counterparty()
                {
                    PopupApp_Counterparty_FIO = FIO.Text,
                    PopupApp_Counterparty_Location = Loc.Text,
                    PopupApp_Counterparty_Services = Service.Text,
                });
                dbEntities.SaveChanges();
                treaty_.Pop_Up();
                this.Close();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
