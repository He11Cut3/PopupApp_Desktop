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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using PopupApp.Treaty;
using PopupApp.Report;
using OfficeOpenXml;
using System.IO;
using System.Globalization;

namespace PopupApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PopupApp_dbEntities popupApp_DbEntities = new PopupApp_dbEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Treaty_Click(object sender, RoutedEventArgs e)
        {
            Treaty_Grid.Children.Clear();

            Treaty_UC treaty_UC = new Treaty_UC();

            Treaty_Grid.Children.Add(treaty_UC);

        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            List<PopupApp_Treaty> data = popupApp_DbEntities.PopupApp_Treaty.ToList();

            // Определяем наименования столбцов
            string[] columnNames = new string[] { "Наименование", "Местоположение", "Дата начала договора", "Дата окончания договора", "Договор", "Контрагент", "Стоимость", "Статус" };
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Добавляем лист
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Общий отчёт");

                // Записываем наименования столбцов
                for (int i = 0; i < columnNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Записываем данные
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].PopupApp_Treaty_Name;
                    worksheet.Cells[i + 2, 2].Value = data[i].PopupApp_Treaty_Location;
                    worksheet.Cells[i + 2, 3].Value = data[i].PopupApp_Treaty_Start_Date;
                    worksheet.Cells[i + 2, 4].Value = data[i].PopupApp_Treaty_End_Date;
                    worksheet.Cells[i + 2, 5].Value = data[i].PopupApp_Treaty_Coming;
                    worksheet.Cells[i + 2, 6].Value = data[i].PopupApp_Treaty_Counterparty;
                    worksheet.Cells[i + 2, 7].Value = data[i].PopupApp_Treaty_Cost;
                    worksheet.Cells[i + 2, 8].Value = data[i].PopupApp_Treaty_Status;
                }

                // Сохраняем файл
                File.WriteAllBytes("Общий_отчёт.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Общий_отчёт.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }

        private void Contr_Agen_Click(object sender, RoutedEventArgs e)
        {
            List<string> counterpartyNames = popupApp_DbEntities.PopupApp_Treaty.Select(d => d.PopupApp_Treaty_Counterparty).Distinct().ToList();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                foreach (string counterpartyName in counterpartyNames)
                {
                    // Добавляем лист для текущего контрагента
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(counterpartyName);

                    // Фильтруем договоры для текущего контрагента
                    var counterpartyTreaties = popupApp_DbEntities.PopupApp_Treaty.Where(d => d.PopupApp_Treaty_Counterparty == counterpartyName).ToList();

                    // Записываем наименования столбцов
                    string[] columnNames = new string[] { "Наименование", "Местоположение", "Дата начала договора", "Дата окончания договора", "Договор", "Стоимость", "Статус" };
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = columnNames[i];
                    }

                    // Записываем данные
                    for (int i = 0; i < counterpartyTreaties.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = counterpartyTreaties[i].PopupApp_Treaty_Name;
                        worksheet.Cells[i + 2, 2].Value = counterpartyTreaties[i].PopupApp_Treaty_Location;
                        worksheet.Cells[i + 2, 3].Value = counterpartyTreaties[i].PopupApp_Treaty_Start_Date;
                        worksheet.Cells[i + 2, 4].Value = counterpartyTreaties[i].PopupApp_Treaty_End_Date;
                        worksheet.Cells[i + 2, 5].Value = counterpartyTreaties[i].PopupApp_Treaty_Coming;
                        worksheet.Cells[i + 2, 6].Value = counterpartyTreaties[i].PopupApp_Treaty_Cost;
                        worksheet.Cells[i + 2, 7].Value = counterpartyTreaties[i].PopupApp_Treaty_Status;
                    }
                }

                // Сохраняем файл
                File.WriteAllBytes("Контрагент.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Контрагент.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }

        }

        private void Date_Click(object sender, RoutedEventArgs e)
        {
            List<PopupApp_Treaty> data = popupApp_DbEntities.PopupApp_Treaty.ToList();

            // Определяем наименования столбцов
            string[] columnNames = new string[] { "Наименование", "Местоположение", "Дата начала договора", "Дата окончания договора", "Договор", "Контрагент", "Стоимость", "Статус" };
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Добавляем лист
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Общий отчёт");

                // Записываем наименования столбцов
                for (int i = 0; i < columnNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Группируем данные по кварталам
                var quarterlyData = data.GroupBy(treaty => GetQuarter(treaty.PopupApp_Treaty_Start_Date))
                                        .OrderBy(group => group.Key);

                // Записываем данные
                int rowIndex = 2;
                foreach (var quarter in quarterlyData)
                {
                    // Добавляем заголовок квартала
                    worksheet.Cells[rowIndex, 1].Value = $"Квартал {quarter.Key}";
                    worksheet.Cells[rowIndex, 1, rowIndex, columnNames.Length].Merge = true;
                    rowIndex++;

                    // Добавляем данные по договорам
                    foreach (var treaty in quarter)
                    {
                        worksheet.Cells[rowIndex, 1].Value = treaty.PopupApp_Treaty_Name;
                        worksheet.Cells[rowIndex, 2].Value = treaty.PopupApp_Treaty_Location;
                        worksheet.Cells[rowIndex, 3].Value = treaty.PopupApp_Treaty_Start_Date;
                        worksheet.Cells[rowIndex, 4].Value = treaty.PopupApp_Treaty_End_Date;
                        worksheet.Cells[rowIndex, 5].Value = treaty.PopupApp_Treaty_Coming;
                        worksheet.Cells[rowIndex, 6].Value = treaty.PopupApp_Treaty_Counterparty;
                        worksheet.Cells[rowIndex, 7].Value = treaty.PopupApp_Treaty_Cost;
                        worksheet.Cells[rowIndex, 8].Value = treaty.PopupApp_Treaty_Status;
                        rowIndex++;
                    }
                }

                // Сохраняем файл
                File.WriteAllBytes("Кварталы.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Кварталы.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }

        }
        private int GetQuarter(string dateStr)
        {
            DateTime date = DateTime.Parse(dateStr);
            int month = date.Month;
            if (month <= 3)
            {
                return 1;
            }
            else if (month <= 6)
            {
                return 2;
            }
            else if (month <= 9)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            List<string> counterpartyNames = popupApp_DbEntities.PopupApp_Treaty.Select(d => d.PopupApp_Treaty_Counterparty).Distinct().ToList();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                foreach (string counterpartyName in counterpartyNames)
                {
                    // Создаем словарь для хранения договоров по местоположению
                    Dictionary<string, List<PopupApp_Treaty>> treatiesByLocation = new Dictionary<string, List<PopupApp_Treaty>>();

                    // Фильтруем договоры для текущего контрагента
                    var counterpartyTreaties = popupApp_DbEntities.PopupApp_Treaty.Where(d => d.PopupApp_Treaty_Counterparty == counterpartyName).ToList();

                    // Группируем договоры по местоположению
                    foreach (var treaty in counterpartyTreaties)
                    {
                        if (!treatiesByLocation.ContainsKey(treaty.PopupApp_Treaty_Location))
                        {
                            treatiesByLocation[treaty.PopupApp_Treaty_Location] = new List<PopupApp_Treaty>();
                        }

                        treatiesByLocation[treaty.PopupApp_Treaty_Location].Add(treaty);
                    }

                    // Добавляем листы для каждого местоположения
                    foreach (var kvp in treatiesByLocation)
                    {
                        // Получаем местоположение и список договоров для текущего листа
                        string location = kvp.Key;
                        List<PopupApp_Treaty> treaties = kvp.Value;

                        string worksheetName = $"{counterpartyName} - {location}";

                        // Добавляем лист для текущего местоположения
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetName);

                        // Записываем наименования столбцов
                        string[] columnNames = new string[] { "Наименование", "Местоположение", "Дата начала договора", "Дата окончания договора", "Договор", "Стоимость", "Статус" };
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = columnNames[i];
                        }

                        // Записываем данные
                        for (int i = 0; i < treaties.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = treaties[i].PopupApp_Treaty_Name;
                            worksheet.Cells[i + 2, 2].Value = treaties[i].PopupApp_Treaty_Location;
                            worksheet.Cells[i + 2, 3].Value = treaties[i].PopupApp_Treaty_Start_Date;
                            worksheet.Cells[i + 2, 4].Value = treaties[i].PopupApp_Treaty_End_Date;
                            worksheet.Cells[i + 2, 5].Value = treaties[i].PopupApp_Treaty_Coming;
                            worksheet.Cells[i + 2, 6].Value = treaties[i].PopupApp_Treaty_Cost;
                            worksheet.Cells[i + 2, 7].Value = treaties[i].PopupApp_Treaty_Status;
                        }
                    }
                }
                File.WriteAllBytes("Локация.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Локация.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}
