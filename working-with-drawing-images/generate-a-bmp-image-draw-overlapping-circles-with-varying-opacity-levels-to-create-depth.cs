using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\circles.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image bound to the output file
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize Graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // First overlapping circle (red, 50% opacity)
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Red;
                    brush.Opacity = 0.5f; // 0 = fully visible, 1 = fully opaque
                    graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle(50, 50, 200, 200));
                }

                // Second overlapping circle (blue, 30% opacity)
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Blue;
                    brush.Opacity = 0.3f;
                    graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle(150, 150, 200, 200));
                }

                // Third overlapping circle (green, 70% opacity)
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Green;
                    brush.Opacity = 0.7f;
                    graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle(250, 80, 200, 200));
                }

                // Save the bound image (no need to specify options again)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}