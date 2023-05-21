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
    /// Логика взаимодействия для Add_Treaty.xaml
    /// </summary>
    public partial class Add_Treaty : Window
    {
        private PopupApp_dbEntities dbEntities;
        private Treaty_UC treaty_;

        public Add_Treaty(PopupApp_dbEntities dbEntities, Treaty_UC treaty_)
        {
            InitializeComponent();
            this.dbEntities = dbEntities;
            this.treaty_ = treaty_;
        }

        private void New_Traty_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                byte[] imageBytes = File.ReadAllBytes(filePath);
                dbEntities.PopupApp_Treaty.Add(new PopupApp_Treaty()
                {
                    PopupApp_Treaty_Name = Name.Text,
                    PopupApp_Treaty_Location = Location.Text,
                    PopupApp_Treaty_Number_Treaty = Number.Text,
                    PopupApp_Treaty_Services = Service.Text,
                    PopupApp_Treaty_Start_Date = Date_Start.SelectedDate?.ToString("dd.MM.yyyy"),
                    PopupApp_Treaty_End_Date = Date_End.SelectedDate?.ToString("dd.MM.yyyy"),
                    PopupApp_Treaty_Coming = (myComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    PopupApp_Treaty_Counterparty = Contr.Text,
                    PopupApp_Treaty_File_Name = fileName,
                    PopupApp_Treaty_File = imageBytes,
                    PopupApp_Treaty_Cost = Cost.Text,
                    PopupApp_Treaty_Status = (myComboBox1.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                });
                dbEntities.SaveChanges();
                treaty_.Pop_Up();
                this.Close();
            }
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
