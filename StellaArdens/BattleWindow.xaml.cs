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
        public Battle Battle { get; set; }

        public BattleWindow()
        {
            InitializeComponent();

            Battle = GameCreator.CreateSmallBattle();
            InitFromBattle(Battle);

            this.UpdateLayout();
        }

        public void InitFromBattle(Battle b)
        {
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

            /*
            bc.ShipsStackPanel.Children.Add(sbuc1);
            bc.ShipsStackPanel.Children.Add(sbuc2);

            StackPanel1.Children.Add(bc);
            */
            CreateRangeBands(b);

        }

        public void CreateRangeBands(Battle b)
        {
            // clear existing children
            BattleDockPanel.Children.Clear();

            // first side on the left


            // second seide on the right


            Division d1 = new Division() { Name = "Division1" };
            Ship s1 = new Ship() { Name = "Ship 1" };
            Ship s2 = new Ship() { Name = "Ship 2" };
            Ship s3 = new Ship() { Name = "Ship 3" };
            Ship s4 = new Ship() { Name = "Ship 4" };
            d1.Ships.Add(s1);
            d1.Ships.Add(s2);
            d1.Ships.Add(s3);
            d1.Ships.Add(s4);

            UI.BattleUserControl bc = new UI.BattleUserControl();
            bc.DataContext = d1;

            UI.ShipBattleUserControl sbuc1 = new UI.ShipBattleUserControl();
            sbuc1.DataContext = s1;

            UI.ShipBattleUserControl sbuc2 = new UI.ShipBattleUserControl();
            sbuc2.DataContext = s2;

            UI.ShipBattleUserControl sbuc3 = new UI.ShipBattleUserControl();
            sbuc3.DataContext = s3;

            UI.ShipBattleUserControl sbuc4 = new UI.ShipBattleUserControl();
            sbuc4.DataContext = s4;

            StackPanel sp1 = new StackPanel();
            sp1.Background = Brushes.Blue;
            sp1.Children.Add(sbuc1);

            DockPanel.SetDock(sp1, Dock.Left);
            BattleDockPanel.Children.Add(sp1);

            StackPanel sp2 = new StackPanel();
            sp2.Background = Brushes.Red;
            sp2.Children.Add(sbuc2);

            DockPanel.SetDock(sp2, Dock.Right);
            BattleDockPanel.Children.Add(sp2);

            StackPanel sp3 = new StackPanel();
            sp3.Background = Brushes.LightSalmon;
            sp3.Children.Add(sbuc3);
            sp3.Children.Add(sbuc4);

            DockPanel.SetDock(sp3, Dock.Right);
            BattleDockPanel.Children.Add(sp3);


            BattleDockPanel.Children.Add(new Label());
        }
    }
}
