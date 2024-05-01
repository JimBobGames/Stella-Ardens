using StellaArdens.Data.Engine;
using StellaArdens.Data.Game;
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
            controller.TurnResolutionEngine = new TurnResolutionEngine();
            controller.Game = TestGameCreator.CreateTestGame();
            controller.RaceReport = controller.TurnResolutionEngine.GenerateReportForRace(controller.Game.Player.RaceId, controller.Game);

            UpdateAfterTurn();
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
    }
}