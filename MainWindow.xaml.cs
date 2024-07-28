using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lb10_mdk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> numbers = new List<int>();

        string filePath = "C:\\Users\\HP\\source\\repos\\lab10_mdk\\lab10_mdk\\file1.txt";
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxt.Text))
            {
                MessageBox.Show("имя файла не введена");
            }
            else if (File.Exists(filePath))
            {
                MessageBox.Show("Файл с таким именем уже существует");
            }
            else
            {
                filePath = $"C:/Users/HP/source/repos/lb10_mdk/lb10_mdk/{nametxt.Text}.txt";
                File.Create(filePath).Close();
                MessageBox.Show("файл успешно создан)");
                nametxt.Text = "";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
           
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < r.Next(20, 80); i++)
                    {
                        writer.WriteLine(r.Next(10, 80));
                    }
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                       
                        if (int.TryParse(line, out int number))
                        {
                            numbers.Add(number);
                        }
                        else
                        {
                            MessageBox.Show($"ощибка преобразования строка {line} в число");
                        }

                    }
                    MessageBox.Show("Данные внесены в файл");
                    mylb.ItemsSource = numbers;
                }
            
      
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines(filePath);

            
            double sum = 0;
            double product = 1;

           foreach (string line in lines)
            {
               
                if (double.TryParse(line, out double number))
                {
                    sum += number;
                    product *= number;
                }
                else
                {
                    MessageBox.Show($"Некорректное значение: {line}");
                }
            }
            result.Text = "";
            result.Text += $"Модуль суммы: {Math.Abs(sum)}";
            result.Text += "\n";
            result.Text += $"Квадрат произведения: {Math.Round(Math.Pow(product, 2), 2)}";
        }


    }
}