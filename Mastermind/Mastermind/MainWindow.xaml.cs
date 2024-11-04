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

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _colors = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
        private readonly string[] _generatedCode = new string[4];

        public MainWindow()

        {
            InitializeComponent();
            GenerateRandomCode();
            FillComboBoxes();
        }
        private void GenerateRandomCode()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                _generatedCode[i] = _colors[random.Next(_colors.Count)];
            }
            this.Title = $"Mastermind - Code: {string.Join(", ", _generatedCode)}";
        }
        private void FillComboBoxes()
        {
            foreach (var color in _colors)
            {
                ComboBox1.Items.Add(color);
                ComboBox2.Items.Add(color);
                ComboBox3.Items.Add(color);
                ComboBox4.Items.Add(color);
            }
        }
    }
}