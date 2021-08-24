using StellaArdens.Core.Data;
using StellaArdens.Core.Hex;
using StellaArdens.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static StellaArdens.Core.Hex.HexMap;

namespace StellaArdens.Renderer
{
    /// <summary>
    /// https://www.c-sharpcorner.com/UploadFile/393ac5/frameworkelement-class-in-wpf/
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging
    /// </summary>

    public class MapVisualHost : FrameworkElement
    {
        private List<Visual> m_Visuals = new List<Visual>();
        private IStellaArdensGame game = null;
        private HexMap hexMap;
        private Layout layout;
        private Pen gridPen;

        public MapVisualHost(IStellaArdensGame game)
        {
            this.game = game;
            this.ClipToBounds = false;
            this.hexMap = HexMap.CreateMap(20, 20);
            this.layout = new Layout(Layout.flat, new Core.Hex.Point(32,32), new Core.Hex.Point(0,0));


            // Create a Pen to add to the GeometryDrawing created above.
            gridPen = new Pen();
            gridPen.Thickness = 1;
            gridPen.LineJoin = PenLineJoin.Round;
            gridPen.EndLineCap = PenLineCap.Round;
            gridPen.Brush = System.Windows.Media.Brushes.White;

            //DrawScreen();

            CreateMapVisuals();
            m_Visuals.Add(CreateDrawingVisualRectangle());
            //_children.Add(CreateDrawingVisualText());
            //_children.Add(CreateDrawingVisualEllipses());

            // Add the event handler for MouseLeftButtonUp.
            //this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);


        }

        class Battalion
        {
            public string ShortName { get; internal set; }

            internal int GetWidthInPaces()
            {
                return 100;
            }

            internal int GetDepthInPaces()
            {
                return 15;
            }
        }

        private void DrawHexMap(DrawingContext dc, HexMap map)
        {
            //OnDrawMapHex del = (MapHex m) => Console.WriteLine("Called lambda expression: " + msg);


            map.AllHexesInMapCoords( (MapHex mh) => 
            {
                List<Core.Hex.Point> points = layout.PolygonCorners(mh.h);


                // draw corners
                foreach(Core.Hex.Point p in points)
                {
                    Rect rect = new Rect(new System.Windows.Point(p.x, p.y), new System.Windows.Size(2, 2));
                    dc.DrawRectangle(System.Windows.Media.Brushes.Blue, (System.Windows.Media.Pen)null, rect);
                }

                // draw center
                Core.Hex.Point cn = layout.HexCenter(mh.h);
                Rect rect2 = new Rect(new System.Windows.Point(cn.x, cn.y), new System.Windows.Size(2, 2));
                dc.DrawRectangle(System.Windows.Media.Brushes.Yellow, (System.Windows.Media.Pen)null, rect2);

                // draw all hex sides
                if (IsBorderHex(mh))
                {
                    for (int i = 0; i < 5; i++)
                    { 
                    dc.DrawLine(gridPen,
                        new System.Windows.Point(points[i].x, points[i].y),
                        new System.Windows.Point(points[i+1].x, points[i+1].y));
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        dc.DrawLine(gridPen,
                            new System.Windows.Point(points[i].x, points[i].y),
                            new System.Windows.Point(points[i + 1].x, points[i + 1].y));
                    }

                }

            });
        }

        private bool IsBorderHex(MapHex mh)
        {
            return (mh.h.q == 0) || (mh.h.r == 0);
        }

        //private void OnDrawMapHex(MapHex mh)
        // {
        //}

        private void DrawCounter(DrawingContext dc, Counter c)
        {
            int width = 40;
            int height = 40;

            int halfwidth = width / 2;
            int halfheight = height / 2;

            Hex h = hexMap.GetHex(c.MapLocation);
            Core.Hex.Point cn = layout.HexCenter(h);

            System.Console.WriteLine("Center = " + cn.x + " " + cn.y);

            int x = (int) cn.x - width / 2;
            int y = (int) cn.y - height / 2;


            // push the counter angle
            int angle = ((int)c.MapCounter.HexFacing);
            dc.PushTransform(new RotateTransform(angle, x + halfwidth, y + halfheight));

            Rect rect = new Rect(new System.Windows.Point(x, y), new System.Windows.Size(width, height));
            dc.DrawRectangle(c.Brush, (System.Windows.Media.Pen)null, rect);

            dc.DrawText(


           new FormattedText(c.Name,
              CultureInfo.GetCultureInfo("en-us"),
              FlowDirection.LeftToRight,
              new Typeface("Verdana"),
              12, System.Windows.Media.Brushes.Black, 1.25d),
              new System.Windows.Point(x, y + height));


            // remove the rotation transform
            dc.Pop();
        }

            private void DrawRegiment(DrawingContext dc, int x, int y, int angle, Battalion bn)
        {
            int width = bn.GetWidthInPaces();
            int halfwidth = width / 2;
            int height = bn.GetDepthInPaces();

            dc.PushTransform(new RotateTransform(angle, x + halfwidth, y));

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new System.Windows.Point(x, y), new System.Windows.Size(width, height));
            dc.DrawRectangle(System.Windows.Media.Brushes.Blue, (System.Windows.Media.Pen)null, rect);

            //Rect rect2 = new Rect(new System.Windows.Point(x, y + height), new System.Windows.Size(width, 10));
            //dc.DrawRectangle(System.Windows.Media.Brushes.Black, (System.Windows.Media.Pen)null, rect2);

            /*
            Rect rect3 = new Rect(new System.Windows.Point(x + (halfwidth - widgetsize) //150
            , y - widgetsize), new System.Windows.Size(20, 10));
            dc.DrawRectangle(System.Windows.Media.Brushes.Red, (System.Windows.Media.Pen)null, rect3);
            */
            dc.DrawText(
               

           new FormattedText(bn.ShortName,
              CultureInfo.GetCultureInfo("en-us"),
              FlowDirection.LeftToRight,
              new Typeface("Verdana"),
              12, System.Windows.Media.Brushes.Black, 1.25d),
              new System.Windows.Point(x, y + height));

            

            dc.Pop();
        }


        private void CreateMapVisuals()
        {
            foreach(SolarSystem ss in game.GalacticMap.SolarSystemsListUnsorted)
            {

            }
        }

        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            //drawingVisual.Transform = new TranslateTransform(100, 100 + offsety);

            // Retrieve the DrawingContext in order to create new drawing content.
            using (DrawingContext dc = drawingVisual.RenderOpen())
            {
                //Rect rect = new Rect(new System.Windows.Point(50, 50), new System.Windows.Size(100, 100));
                //dc.DrawRectangle(System.Windows.Media.Brushes.Blue, (System.Windows.Media.Pen)null, rect);
                DrawHexMap(dc, hexMap);



                //DrawRegiment(dc, 20, 20, 45, new Battalion() { ShortName = "1st NY" } );
                //DrawRegiment(dc, 120, 20, 45, new Battalion() { ShortName = "2nd NY" });
                //DrawRegiment(dc, 220, 20, 45, new Battalion() { ShortName = "3rd NY" });


                DrawCounter(dc,new Counter() { 
                    MapLocation = new Core.Hex.Point(5, 5), 
                    Brush = System.Windows.Media.Brushes.Green,
                    MapCounter = new Ship()
                    { Name = "Flower", HexFacing = HexFacing.NorthWest} });

            }


            // Persist the drawing content.
            //drawingContext.Close();



            return drawingVisual;
        }
        protected override int VisualChildrenCount
        {
            get { return m_Visuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= m_Visuals.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return m_Visuals[index];
        }
    }
}

        /*
    public void DrawScreen(ManeBellumWPFClientGame client)
    {
        // Remove all Visuals
        m_Visuals.ForEach(delegate (Visual v) { RemoveVisualChild(v); });
        m_Visuals.Clear();

        m_Visuals.Add(CreateDrawingVisualRectangle(client));

        m_Visuals.ForEach(delegate (Visual v) { AddVisualChild(v); });
    }



    /// <summary>
    /// https://www.codeproject.com/Articles/33308/Draw-a-Boardgame-in-WPF
    /// </summary>

    int offsety = 1;

    /// <returns></returns>
    // Create a DrawingVisual that contains a rectangle.
    private DrawingVisual CreateDrawingVisualRectangle(ManeBellumWPFClientGame client)
    {
        DrawingVisual drawingVisual = new DrawingVisual();
        //drawingVisual.Transform = new TranslateTransform(100, 100 + offsety);

        // Retrieve the DrawingContext in order to create new drawing content.
        using (DrawingContext dc = drawingVisual.RenderOpen())
        {


            offsety++;
            //DrawRegiment(dc, 100, 100, 0);
            //DrawRegiment(dc, 390, 110, 1);
            //DrawRegiment(dc, 690, 180, angle);

            foreach (Battalion bn in client.Battalions.Values)
            {
                DrawRegiment(dc, bn.MapX, bn.MapY, bn.MapRotation, bn);
            }

        }


        // Persist the drawing content.
        //drawingContext.Close();



        return drawingVisual;
    }

    //private int height = 80;
    //private int width = 320;
    ///private int halfwidth = 160;
    int widgetsize = 10;

    private void DrawRegiment(DrawingContext dc, int x, int y, int angle, Battalion bn)
    {
        int width = bn.GetWidthInPaces();
        int halfwidth = width / 2;
        int height = bn.GetDepthInPaces();

        dc.PushTransform(new RotateTransform(angle, x + halfwidth, y));

        // Create a rectangle and draw it in the DrawingContext.
        Rect rect = new Rect(new System.Windows.Point(x, y), new System.Windows.Size(width, height));
        dc.DrawRectangle(System.Windows.Media.Brushes.Red, (System.Windows.Media.Pen)null, rect);

        Rect rect2 = new Rect(new System.Windows.Point(x, y + height), new System.Windows.Size(width, 10));
        dc.DrawRectangle(System.Windows.Media.Brushes.Black, (System.Windows.Media.Pen)null, rect2);

        Rect rect3 = new Rect(new System.Windows.Point(x + (halfwidth - widgetsize)  // 150
        , y - widgetsize), new System.Windows.Size(20, 10));
        dc.DrawRectangle(System.Windows.Media.Brushes.Red, (System.Windows.Media.Pen)null, rect3);

        dc.DrawText(
       new FormattedText(bn.ShortName,
          CultureInfo.GetCultureInfo("en-us"),
          FlowDirection.LeftToRight,
          new Typeface("Verdana"),
          36, System.Windows.Media.Brushes.Black),
          new System.Windows.Point(x, y));

        dc.Pop();
    }
}
}
*/