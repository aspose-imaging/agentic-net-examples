using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options
        BmpOptions bmpOptions = new Aspose.Imaging.ImageOptions.BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Create a GraphicsPath to hold figures
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();

            // First figure with ellipse and pie
            Aspose.Imaging.Figure figure1 = new Aspose.Imaging.Figure();
            figure1.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(50, 50, 300, 300)));
            figure1.AddShape(new Aspose.Imaging.Shapes.PieShape(
                new Aspose.Imaging.Rectangle(new Aspose.Imaging.Point(110, 110), new Aspose.Imaging.Size(200, 200)),
                0, 90));

            // Second figure with arc, polygon, and rectangle
            Aspose.Imaging.Figure figure2 = new Aspose.Imaging.Figure();
            figure2.AddShape(new Aspose.Imaging.Shapes.ArcShape(new Aspose.Imaging.RectangleF(10, 10, 300, 300), 0, 45));
            figure2.AddShape(new Aspose.Imaging.Shapes.PolygonShape(
                new[] {
                    new Aspose.Imaging.PointF(150, 10),
                    new Aspose.Imaging.PointF(150, 200),
                    new Aspose.Imaging.PointF(250, 300),
                    new Aspose.Imaging.PointF(350, 400)
                }, true));
            figure2.AddShape(new Aspose.Imaging.Shapes.RectangleShape(
                new Aspose.Imaging.RectangleF(
                    new Aspose.Imaging.Point(250, 250),
                    new Aspose.Imaging.Size(200, 200))));

            // Append both figures to the path
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Render the path
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicsPath);

            // Save the image
            image.Save();
        }
    }
}