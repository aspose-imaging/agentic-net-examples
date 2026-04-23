using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = "output/output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options with file source
        var bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath);

        // Create a 400x400 BMP image
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Draw first overlapping circle (red, 50% opacity)
            using (SolidBrush brush1 = new SolidBrush(Color.Red))
            {
                brush1.Opacity = 0.5f;
                graphics.FillEllipse(brush1, new Rectangle(50, 50, 200, 200));
            }

            // Draw second overlapping circle (blue, 40% opacity)
            using (SolidBrush brush2 = new SolidBrush(Color.Blue))
            {
                brush2.Opacity = 0.4f;
                graphics.FillEllipse(brush2, new Rectangle(150, 100, 200, 200));
            }

            // Draw third overlapping circle (green, 30% opacity)
            using (SolidBrush brush3 = new SolidBrush(Color.Green))
            {
                brush3.Opacity = 0.3f;
                graphics.FillEllipse(brush3, new Rectangle(100, 150, 200, 200));
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}