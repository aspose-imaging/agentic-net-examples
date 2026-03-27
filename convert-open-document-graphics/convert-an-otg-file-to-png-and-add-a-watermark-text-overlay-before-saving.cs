using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.png");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Convert OTG to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            using (var pngOptions = new PngOptions())
            {
                otgImage.Save(outputPath, pngOptions);
            }
        }

        // Add watermark text overlay
        using (Image pngImage = Image.Load(outputPath))
        {
            // Cast to RasterImage for drawing
            RasterImage rasterImage = (RasterImage)pngImage;

            // Create graphics for the raster image
            Graphics graphics = new Graphics(rasterImage);

            // Define font and brush
            Font font = new Font("Arial", 48);
            using (var brush = new SolidBrush(Color.Yellow))
            {
                // Position the watermark near the bottom-left corner
                Point position = new Point(10, rasterImage.Height - 60);
                graphics.DrawString("Watermark", font, brush, position);
            }

            // Save the image with the watermark
            pngImage.Save(outputPath);
        }
    }
}