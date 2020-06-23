using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Renderer
{
    public class MapRenderer
    {
    }
}

/*
public class MapVisualHost : FrameworkElement
{
    // Create a collection of child visual objects.
    private List<Visual> m_Visuals = new List<Visual>();
    private int angle = 45;

    public MapVisualHost()
    {
        this.ClipToBounds = false;

        //DrawScreen();


        //m_Visuals.Add(CreateDrawingVisualRectangle());
        //_children.Add(CreateDrawingVisualText());
        //_children.Add(CreateDrawingVisualEllipses());

        // Add the event handler for MouseLeftButtonUp.
        //this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
    }

    public void DrawScreen(ManeBellumWPFClientGame client)
    {
        // Remove all Visuals
        m_Visuals.ForEach(delegate (Visual v) { RemoveVisualChild(v); });
        m_Visuals.Clear();

        m_Visuals.Add(CreateDrawingVisualRectangle(client));

        m_Visuals.ForEach(delegate (Visual v) { AddVisualChild(v); });
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

        Rect rect3 = new Rect(new System.Windows.Point(x + (halfwidth - widgetsize) //150
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