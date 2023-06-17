using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PopupApp.Treaty
{
    /// <summary>
    /// Логика взаимодействия для Treaty_UC.xaml
    /// </summary>
    public partial class Treaty_UC : System.Windows.Controls.UserControl
    {
        PopupApp_dbEntities popupApp_DbEntities = new PopupApp_dbEntities();
        List<PopupApp_Treaty> popupApp_Treaties = new List<PopupApp_Treaty>();


        List<PopupApp_Treaty> incomingTreaties = new List<PopupApp_Treaty>();
        List<PopupApp_Treaty> outgoingTreaties = new List<PopupApp_Treaty>();

        public Treaty_UC()
        {
            InitializeComponent();
            Pop_Up();
        }

        public void Pop_Up()
        {
            incomingTreaties = popupApp_DbEntities.PopupApp_Treaty.Where(t => t.PopupApp_Treaty_Coming == "Входящий").ToList();
            outgoingTreaties = popupApp_DbEntities.PopupApp_Treaty.Where(t => t.PopupApp_Treaty_Coming == "Исходящий").ToList();

            // Отображение информации о входящих договорах в первом ListView
            listView_input.ItemsSource = incomingTreaties.OrderBy(t => t.PopupApp_Treaty_id).ToList();

            // Отображение информации об исходящих договорах во втором ListView
            listView_OutPut.ItemsSource = outgoingTreaties.OrderBy(t => t.PopupApp_Treaty_id).ToList();
        }


        private void New_Treaty_Click(object sender, RoutedEventArgs e)
        {
            Add_Treaty add_Treaty = new Add_Treaty(popupApp_DbEntities, this);
            add_Treaty.ShowDialog();
        }

        private void Find_Inf_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = Find_Inf.Text;
            var query = from emp in popupApp_DbEntities.PopupApp_Treaty
                        where emp.PopupApp_Treaty_Name.Contains(searchText) || emp.PopupApp_Treaty_Coming.Contains(searchText) || emp.PopupApp_Treaty_Cost.Contains(searchText) || emp.PopupApp_Treaty_Counterparty.Contains(searchText) || emp.PopupApp_Treaty_End_Date.Contains(searchText) || emp.PopupApp_Treaty_Location.Contains(searchText) || emp.PopupApp_Treaty_Services.Contains(searchText) || emp.PopupApp_Treaty_Number_Treaty.Contains(searchText)
                        select emp;

            listView_input.ItemsSource = query.ToList();
            listView_OutPut.ItemsSource = query.ToList();
        }

        private void Edit_Treaty_Click(object sender, RoutedEventArgs e)
        {
            Edit_Treaty edit_Treaty = new Edit_Treaty(popupApp_DbEntities, this, sender);
            edit_Treaty.ShowDialog();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var item = button.DataContext as PopupApp_Treaty;
            popupApp_DbEntities.PopupApp_Treaty.Remove(item);
            popupApp_DbEntities.SaveChanges();
            Pop_Up();
        }

        private void Dow_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;

            // Получаем элемент списка, связанный с кнопкой
            var item = button.DataContext as PopupApp_Treaty;

            // Получаем данные файла из базы данных

            string fileName = item.PopupApp_Treaty_File_Name;
            byte[] fileData = item.PopupApp_Treaty_File;

            // Если данные файла есть, то открываем файл
            if (fileData != null && fileData.Length > 0)
            {
                // Получаем путь к рабочему столу
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                // Создаем путь для сохранения файла на рабочем столе
                string filePath = System.IO.Path.Combine(desktopPath, fileName);

                // Сохраняем файл на рабочий стол
                File.WriteAllBytes(filePath, fileData);
            }
        }
    }
}
