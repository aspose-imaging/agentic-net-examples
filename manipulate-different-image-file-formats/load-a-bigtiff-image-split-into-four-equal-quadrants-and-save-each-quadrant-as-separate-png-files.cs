using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\bigimage.tif";
            string outputDir = @"C:\Images\Quadrants";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Determine half dimensions
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define bounds for the four quadrants
                var quadrants = new[]
                {
                    new Rectangle(0, 0, halfWidth, halfHeight),                     // Top‑Left
                    new Rectangle(halfWidth, 0, halfWidth, halfHeight),            // Top‑Right
                    new Rectangle(0, halfHeight, halfWidth, halfHeight),           // Bottom‑Left
                    new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight)   // Bottom‑Right
                };

                // Save each quadrant as a separate PNG file
                for (int i = 0; i < quadrants.Length; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"quadrant{i + 1}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the specified rectangle using PNG options
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions, quadrants[i]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}