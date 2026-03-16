using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class FillPolygonExample
{
    static void Main()
    {
        // Define image size
        int width = 400;
        int height = 300;

        // Create PNG options and set the output file as the source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource("filled_polygon.png", false);

        // Create a new image with the specified dimensions
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background with a light color
            graphics.Clear(Color.Wheat);

            // Define polygon vertices
            Point[] polygonPoints = new Point[]
            {
                new Point(50, 50),
                new Point(350, 40),
                new Point(300, 200),
                new Point(100, 250)
            };

            // Create a solid brush with the desired fill color
            SolidBrush brush = new SolidBrush();
            brush.Color = Color.CornflowerBlue; // fill color
            brush.Opacity = 100; // fully opaque

            // Fill the polygon using the brush and points
            graphics.FillPolygon(brush, polygonPoints);

            // Save the image to the file specified in the options
            image.Save();
        }
    }
}