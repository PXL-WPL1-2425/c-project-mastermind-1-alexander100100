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


        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            ComboBox1.ItemsSource = colors;
            ComboBox2.ItemsSource = colors;
            ComboBox3.ItemsSource = colors;
            ComboBox4.ItemsSource = colors;
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

        }
    }
}