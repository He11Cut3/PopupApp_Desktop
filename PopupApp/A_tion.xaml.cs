using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PopupApp
{
    /// <summary>
    /// Логика взаимодействия для A_tion.xaml
    /// </summary>
    public partial class A_tion : Window
    {
        private string text = String.Empty;
        PopupApp_dbEntities _context = new PopupApp_dbEntities();

        public A_tion()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DragMove();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void A_t_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password.Password;
            PopupApp_User users = null;
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                users = (PopupApp_User)_context.PopupApp_User.Where(b => b.PopupApp_User_Login == login && b.PopupApp_User_Password == password).FirstOrDefault();
            }
            if (users != null)
            {
                MainWindow main = new MainWindow();
                this.Close();
                main.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}
