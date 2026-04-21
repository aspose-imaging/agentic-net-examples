using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DngImage (inherits RasterCachedImage -> RasterImage)
            DngImage dngImage = (DngImage)image;
            RasterImage raster = (RasterImage)dngImage;

            // Create graphics object for drawing
            Graphics graphics = new Graphics(raster);

            // Define semi‑transparent white brush (50% opacity)
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255));

            // Define font for watermark text
            Font font = new Font("Arial", 48);

            // Position watermark near bottom‑right corner
            float x = raster.Width - 250; // adjust as needed
            float y = raster.Height - 70; // adjust as needed
            graphics.DrawString("Watermark", font, brush, new PointF(x, y));

            // Save the result as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}