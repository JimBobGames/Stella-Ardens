using StellaArdens.Core.Data;
using StellaArdens.Core.Persistence;
using StellaArdens.Renderer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// </summary
    /// >

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

        //private void InitializeComponent()
       // {
            //throw new NotImplementedException();
        //}
    }




    /// <summary>
    /// Interaction logic for Window1.xaml
/// </summary>

     public partial class MainWindow2 : Window
     {
        private StellaArdensGame game = null;
        private StateList states = new StateList();

 

        public MainWindow2()

        {

             //InitializeComponent();

            game = GameLoader.CreateGame();



            CountyList countyList1 = new CountyList();

              County county1 = new County();

            county1.Name = "Frederick";

             county1.Area = "667 sq mi";

             county1.Population = "220,701";

             CityList cities1 = new CityList();

            cities1.Add(new City("Frederick", "59,220", "20.4 sq mi"));

             cities1.Add(new City("Brunswick", "4,894", "2.1 sq mi"));

              cities1.Add(new City("Middletown", "2,668", "1.7 sq mi"));

             cities1.Add(new City("New Market", "427", "0.7 sq mi"));

             county1.Cities = cities1;

 

             countyList1.Add(county1);



             County county2 = new County();

             county2.Name = "Montgomery";

            county2.Area = "507 sq mi";

             county2.Population = "950,680";

            CityList cities2 = new CityList();

             cities2.Add(new City("Gaithersburg", "58,744", "10.2 sq mi"));

             cities2.Add(new City("Rockville", "60,734", "13.4 sq mi"));

             cities2.Add(new City("Takoma Park", "17,299", "2.36 sq mi"));

             cities2.Add(new City("Chevy Chase", "2,726", "0.5 sq mi"));

             county2.Cities = cities2;

 

             countyList1.Add(county2);

 

             State state1 = new State();

             state1.Name = "Maryland";

             state1.NickName = "Old Line State";

             state1.Counties = countyList1;

 

             state1.Counties = countyList1;



             states.Add(state1);

 

             DataContext = game.Player.Nation.KnownSolarSystems;

         }

     }



     public class City

    {

         public City()

        {

        }

 

         public City(String name, String population, String area)

         {

              Name = name;

              Population = population;

             Area = area;

         }

 

         public String Name

         { get; set; }

 

         public String Population

         { get; set; }

 

        public String Area

         { get; set; }

     }

 

    public class CityList : ObservableCollection<City>

    {

     }

  

     public class County

    {

        public County()

        {

            Cities = new CityList();

         }

 

         public String Name

         { get; set; }

 
         public String Population

         { get; set; }

 

         public String Area

         { get; set; }

        public CityList Cities
         { get; set; }

     }



     public class CountyList : ObservableCollection<County>

     {

    }

 

     public class State

     {

         public State()

        {

            Counties = new CountyList();

        }


        public String Name
         { get; set; }

 

         public String NickName
         { get; set; }

 

         public CountyList Counties

         { get; set; }

    }

 

     public class StateList : ObservableCollection<State>

     {

    }

 }

 


