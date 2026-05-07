using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (high‑DPI BMP)
            string outputPath = @"C:\temp\highdpi_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with resolution and source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300.0, 300.0);
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a BMP image canvas (800x600) bound to the output file
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 800, 600))
            {
                // Create a Graphics object for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a red diagonal line
                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 5);
                graphics.DrawLine(redPen,
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(image.Width - 1, image.Height - 1));

                // Fill a blue rectangle
                using (SolidBrush blueBrush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillRectangle(blueBrush,
                        new Aspose.Imaging.Rectangle(100, 100, 300, 200));
                }

                // Draw a green ellipse
                Aspose.Imaging.Pen greenPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 3);
                graphics.DrawEllipse(greenPen,
                    new Aspose.Imaging.Rectangle(250, 150, 200, 150));

                // Save the bound image (no path needed)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}