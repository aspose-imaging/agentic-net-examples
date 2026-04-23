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
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF background as a raster image
        using (RasterImage background = (RasterImage)Image.Load(inputPath))
        {
            // Create an in‑memory overlay image (200x150)
            using (MemoryStream ms = new MemoryStream())
            {
                Source overlaySource = new StreamSource(ms);
                PngOptions overlayOptions = new PngOptions() { Source = overlaySource };

                using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, 200, 150))
                {
                    // Draw a semi‑transparent red rectangle onto the overlay
                    Graphics graphics = new Graphics(overlay);
                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        brush.Opacity = 128; // 50% opacity
                        graphics.FillRectangle(brush, new Rectangle(0, 0, 200, 150));
                    }

                    // Blend the overlay onto the background at position (50,50)
                    background.Blend(new Point(50, 50), overlay, 255);
                }
            }

            // Save the blended result as a GIF
            GifOptions gifOptions = new GifOptions();
            background.Save(outputPath, gifOptions);
        }
    }
}