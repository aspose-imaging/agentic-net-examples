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
        // Configure BMP options (24‑bit color)
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource("output.bmp", false);

        // Create a 400x400 BMP image
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Obtain a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a background color
            graphics.Clear(Color.Wheat);

            // Define pixel‑aligned polygon vertices
            Point[] polygonPoints = new Point[]
            {
                new Point(50, 300),
                new Point(200, 50),
                new Point(350, 300)
            };

            // Create a solid brush (fully opaque blue)
            SolidBrush brush = new SolidBrush();
            brush.Color = Color.Blue;
            brush.Opacity = 100;

            // Fill the polygon with the solid brush
            graphics.FillPolygon(brush, polygonPoints);

            // Optionally draw the polygon outline
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPolygon(pen, polygonPoints);

            // Persist the image to disk
            image.Save();
        }
    }
}