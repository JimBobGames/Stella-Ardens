﻿using StellaArdens.Data.Engine;
using StellaArdens.Data.Game;
using StellaArdens.Data.Objects;
using StellaArdens.Data.Reports;
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

namespace StellaArdens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent();

            // create the game
            controller.Game = TestGameCreator.CreateTestGame();
            controller.TurnResolutionEngine = new TurnResolutionEngine(controller.Game);
            controller.RaceReport = controller.TurnResolutionEngine.GenerateReportForRace(controller.Game.Player.RaceId, controller.Game);

            // generate debug map
            MapTab.IsSelected = true;
            GenerateDebugMap(controller.Game);

            UpdateAfterTurn();
        }

        private const int XMOD = 10;
        private const int YMOD = 10;
        private void GenerateDebugMap(IStellaArdensGame game)
        {
            MapCanvas.Children.Clear();
            MapCanvas.Background = Brushes.DarkBlue;

            Ellipse e1;

            foreach (SolarSystem ss in game.SolarSystems)
            {
                e1 = new Ellipse();
                e1.Height = 50;
                e1.Width = 50;
                e1.Stroke = Brushes.Red;
                e1.StrokeThickness = 5;
                e1.Fill = Brushes.White;
                Canvas.SetLeft(e1, ss.Location.X * XMOD);
                Canvas.SetTop(e1, ss.Location.Y * YMOD);
                MapCanvas.Children.Add(e1);
            }

            MapCanvas.InvalidateVisual();
        }

        public void UpdateAfterTurn()
        {
            if(controller.RaceReport == null)
            {
                return;
            }
            RaceName.Text = controller.RaceReport.Name + ", Turn " + controller.RaceReport.TurnNumber;
            RaceBank.Text = controller.RaceReport.Bank + " MCr. " ;
        }

        private void EndTurnButton_Click(object sender, RoutedEventArgs e)
        {
            if (controller.TurnResolutionEngine != null)
            {
                // run the turn
                controller.RunTurn();
                UpdateAfterTurn();
            }
        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // when the tab is changed
        }

        private void MapTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           // MapTab
        }
    }
}