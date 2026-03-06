using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Define output file path
        string outputPath = @"c:\temp\filled_polygon.bmp";

        // Create BMP options with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false) // create a new file
        };

        // Create a new BMP image of size 400x400
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background with a light color
            graphics.Clear(Color.Wheat);

            // Define a solid brush for filling the polygon (blue, fully opaque)
            SolidBrush brush = new SolidBrush
            {
                Color = Color.Blue,
                Opacity = 100
            };

            // Define the vertices of the polygon
            Point[] polygonPoints = new Point[]
            {
                new Point(50, 50),
                new Point(350, 80),
                new Point(300, 300),
                new Point(100, 250)
            };

            // Fill the polygon using the brush and points array
            graphics.FillPolygon(brush, polygonPoints);

            // Save the image to the specified path
            image.Save();
        }
    }
}