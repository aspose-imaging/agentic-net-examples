using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\background.gif";
        string outputPath = @"C:\temp\output.gif";

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
            // Define overlay size
            int overlayWidth = 200;
            int overlayHeight = 150;

            // Path for temporary overlay image
            string overlayPath = @"C:\temp\overlay.gif";
            Directory.CreateDirectory(Path.GetDirectoryName(overlayPath));

            // Create a bound GIF canvas for the overlay
            Source overlaySource = new FileCreateSource(overlayPath, false);
            GifOptions overlayOptions = new GifOptions { Source = overlaySource };
            using (GifImage overlayCanvas = (GifImage)Image.Create(overlayOptions, overlayWidth, overlayHeight))
            {
                // Fill the overlay with semi‑transparent red
                Graphics graphics = new Graphics(overlayCanvas);
                SolidBrush brush = new SolidBrush(Color.Red);
                brush.Opacity = 128; // 50% opacity
                graphics.FillRectangle(brush, new Rectangle(0, 0, overlayWidth, overlayHeight));
                // Save the bound overlay image
                overlayCanvas.Save();
            }

            // Load the overlay image for blending
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Blend overlay onto background at position (50,50) with 50% opacity
                background.Blend(new Point(50, 50), overlay, 128);
            }

            // Save the blended result as a GIF
            GifOptions outputOptions = new GifOptions();
            background.Save(outputPath, outputOptions);
        }
    }
}