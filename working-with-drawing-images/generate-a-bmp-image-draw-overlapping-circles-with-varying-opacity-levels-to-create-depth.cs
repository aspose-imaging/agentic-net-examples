using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\circles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a bound file source
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = source;

        int width = 400;
        int height = 400;

        // Create the BMP image (bound to the file)
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Draw first semi‑transparent red circle
            using (SolidBrush brush1 = new SolidBrush())
            {
                brush1.Color = Color.Red;
                brush1.Opacity = 0.5f; // 50% opacity
                graphics.FillEllipse(brush1, new Rectangle(50, 50, 200, 200));
            }

            // Draw second semi‑transparent green circle overlapping the first
            using (SolidBrush brush2 = new SolidBrush())
            {
                brush2.Color = Color.Green;
                brush2.Opacity = 0.5f;
                graphics.FillEllipse(brush2, new Rectangle(150, 150, 200, 200));
            }

            // Draw third semi‑transparent blue circle overlapping the others
            using (SolidBrush brush3 = new SolidBrush())
            {
                brush3.Color = Color.Blue;
                brush3.Opacity = 0.5f;
                graphics.FillEllipse(brush3, new Rectangle(100, 200, 200, 200));
            }

            // Save the bound image (no need to specify options again)
            image.Save();
        }
    }
}