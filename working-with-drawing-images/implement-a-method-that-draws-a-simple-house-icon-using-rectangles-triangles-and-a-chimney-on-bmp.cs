using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\house.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        Source src = new FileCreateSource(outputPath, false);
        bmpOptions.Source = src;

        // Canvas size
        int width = 200;
        int height = 200;

        // Create bound BMP canvas
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Pen for outlines
            Pen blackPen = new Pen(Color.Black, 2);

            // Draw house body
            Rectangle houseRect = new Rectangle(50, 80, 100, 80);
            graphics.DrawRectangle(blackPen, houseRect);
            using (SolidBrush houseBrush = new SolidBrush(Color.LightGray))
            {
                graphics.FillRectangle(houseBrush, houseRect);
            }

            // Draw roof (triangle)
            Point[] roofPoints = new Point[]
            {
                new Point(50, 80),
                new Point(150, 80),
                new Point(100, 30)
            };
            graphics.DrawPolygon(blackPen, roofPoints);
            using (SolidBrush roofBrush = new SolidBrush(Color.DarkRed))
            {
                graphics.FillPolygon(roofBrush, roofPoints);
            }

            // Draw chimney
            Rectangle chimneyRect = new Rectangle(120, 30, 20, 30);
            graphics.DrawRectangle(blackPen, chimneyRect);
            using (SolidBrush chimneyBrush = new SolidBrush(Color.Brown))
            {
                graphics.FillRectangle(chimneyBrush, chimneyRect);
            }

            // Save the bound image
            canvas.Save();
        }
    }
}