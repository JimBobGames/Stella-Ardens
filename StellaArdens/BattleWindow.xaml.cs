using StellaArdens.Core.Data;
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
using System.Windows.Shapes;

namespace StellaArdens
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        public BattleWindow()
        {
            InitializeComponent();

            Division d1 = new Division() { Name = "Division1" };
            Ship s1 = new Ship() { Name = "Ship 1" };
            Ship s2 = new Ship() { Name = "Ship 2" };
            d1.Ships.Add(s1);
            d1.Ships.Add(s2);

            UI.BattleUserControl bc = new UI.BattleUserControl();
            bc.DataContext = d1;

            UI.ShipBattleUserControl sbuc1 = new UI.ShipBattleUserControl();
            sbuc1.DataContext = s1;

            UI.ShipBattleUserControl sbuc2 = new UI.ShipBattleUserControl();
            sbuc2.DataContext = s2;

            bc.ShipsStackPanel.Children.Add(sbuc1);
            bc.ShipsStackPanel.Children.Add(sbuc2);

            StackPanel1.Children.Add(bc);

            //this.UpdateLayout();
        }
    }
}
