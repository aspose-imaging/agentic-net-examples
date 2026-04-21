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
        // Output file path (hardcoded)
        string outputPath = @"c:\temp\venn.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // First ellipse (red)
            using (SolidBrush brush1 = new SolidBrush())
            {
                brush1.Color = Color.Red;
                brush1.Opacity = 50; // 50% opacity
                graphics.FillEllipse(brush1, new Rectangle(50, 150, 200, 200));
            }

            // Second ellipse (green)
            using (SolidBrush brush2 = new SolidBrush())
            {
                brush2.Color = Color.Green;
                brush2.Opacity = 50;
                graphics.FillEllipse(brush2, new Rectangle(150, 150, 200, 200));
            }

            // Third ellipse (blue)
            using (SolidBrush brush3 = new SolidBrush())
            {
                brush3.Color = Color.Blue;
                brush3.Opacity = 50;
                graphics.FillEllipse(brush3, new Rectangle(100, 50, 200, 200));
            }

            // Save the image (source already bound to outputPath)
            image.Save();
        }
    }
}