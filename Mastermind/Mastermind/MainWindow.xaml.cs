using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> colors = new List<string> { "Red", "Yellow", "Orange", "White", "Green", "Blue" };
        private List<string> generatedCode = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();
            GenerateCode();
        }

        private void FillComboBoxes()
        {
            ComboBox1.ItemsSource = colors;
            ComboBox2.ItemsSource = colors;
            ComboBox3.ItemsSource = colors;
            ComboBox4.ItemsSource = colors;
        }
        private void GenerateCode()
        {
            Random random = new Random();
            generatedCode.Clear();
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(colors.Count);
                generatedCode.Add(colors[index]);
            }
            this.Title = $"MasterMind ({string.Join(",", generatedCode)})";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if (sender is ComboBox comboBox)
            {
                string selectedColor = comboBox.SelectedItem as string;

                if (comboBox == ComboBox1)
                    UpdateLabel(Label1, selectedColor);
                else if (comboBox == ComboBox2)
                    UpdateLabel(Label2, selectedColor);
                else if (comboBox == ComboBox3)
                    UpdateLabel(Label3, selectedColor);
                else if (comboBox == ComboBox4)
                    UpdateLabel(Label4, selectedColor);
            }
        }

        private void UpdateLabel(Label label, string colorName)
        {
            if (colorName != null)
            {
                label.Content = colorName;
                label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorName));
            }
            else
            {
                label.Content = "None";
                label.Background = Brushes.White;
            }
        }

        private void Validatebtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> userCode = new List<string>
            {
                ComboBox1.SelectedItem?.ToString(),
                ComboBox2.SelectedItem?.ToString(),
                ComboBox3.SelectedItem?.ToString(),
                ComboBox4.SelectedItem?.ToString()
            };

            if (userCode.Contains(null))
            {
                MessageBox.Show("Please select a color for each slot before validating.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                if (userCode[i] == generatedCode[i])
                {
                    ShowBorder(i, Colors.DarkRed);
                }
                else if (generatedCode.Contains(userCode[i]))
                {
                    ShowBorder(i, Colors.Wheat);
                }
                else
                {
                    ShowBorder(i, Colors.Transparent);
                }
            }
        }

        private void ShowBorder(int index, Color color)
        {
            Brush borderColor = new SolidColorBrush(color);

            switch (index)
            {
                case 0:
                    Label1.BorderBrush = borderColor;
                    Label1.BorderThickness = new Thickness(3);
                    break;
                case 1:
                    Label2.BorderBrush = borderColor;
                    Label2.BorderThickness = new Thickness(3);
                    break;
                case 2:
                    Label3.BorderBrush = borderColor;
                    Label3.BorderThickness = new Thickness(3);
                    break;
                case 3:
                    Label4.BorderBrush = borderColor;
                    Label4.BorderThickness = new Thickness(3);
                    break;
            }
        }
    }
}