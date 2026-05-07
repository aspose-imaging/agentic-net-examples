using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path (hard‑coded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define pen configurations (color, width, start/end points)
                var penConfigs = new[]
                {
                    new { Color = Aspose.Imaging.Color.Red,    Width = 5f,  X1 = 20,  Y1 = 20,  X2 = 480, Y2 = 20 },
                    new { Color = Aspose.Imaging.Color.Green,  Width = 3f,  X1 = 20,  Y1 = 60,  X2 = 480, Y2 = 60 },
                    new { Color = Aspose.Imaging.Color.Blue,   Width = 2f,  X1 = 20,  Y1 = 100, X2 = 480, Y2 = 100 },
                    new { Color = Aspose.Imaging.Color.Black,  Width = 1f,  X1 = 20,  Y1 = 140, X2 = 480, Y2 = 140 }
                };

                // Draw each line using its pen configuration
                foreach (var cfg in penConfigs)
                {
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(cfg.Color, cfg.Width);
                    graphics.DrawLine(pen, cfg.X1, cfg.Y1, cfg.X2, cfg.Y2);
                }

                // Save the image (the file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}