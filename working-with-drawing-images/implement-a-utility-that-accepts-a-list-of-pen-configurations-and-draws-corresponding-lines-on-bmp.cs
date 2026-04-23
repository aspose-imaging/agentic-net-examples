using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output BMP path
        string outputPath = @"C:\temp\lines.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Define line configurations (color, width, start point, end point)
            var lineConfigs = new[]
            {
                new { Pen = new Pen(Color.Red, 2f), Start = new Point(50, 50), End = new Point(450, 50) },
                new { Pen = new Pen(Color.Green, 4f), Start = new Point(50, 100), End = new Point(450, 200) },
                new { Pen = new Pen(Color.Blue, 3f), Start = new Point(50, 250), End = new Point(450, 350) },
                new { Pen = new Pen(Color.Black, 1f), Start = new Point(250, 400), End = new Point(250, 100) }
            };

            // Draw each line using its Pen configuration
            foreach (var cfg in lineConfigs)
            {
                graphics.DrawLine(cfg.Pen, cfg.Start, cfg.End);
            }

            // Save the image (output path is already bound)
            image.Save();
        }
    }
}