using StellaArdens.Core.Data;
using StellaArdens.Core.Persistence;
using StellaArdens.Renderer;
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

namespace StellaArdens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StellaArdensGame game = null;

        public MainWindow()
        {
            InitializeComponent();

            game = GameLoader.CreateGame();

            MapVisualHost mvh = new MapVisualHost(game);
            this.MainWindowCanvas.Children.Add(mvh);
            this.MainWindowCanvas.InvalidateVisual();
        }
    }
}
