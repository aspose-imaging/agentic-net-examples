using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\big.tif";
        string outputDir = @"C:\Images\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (creates if missing)
        Directory.CreateDirectory(outputDir);

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate half dimensions
            int halfWidth = image.Width / 2;
            int halfHeight = image.Height / 2;

            // Define the four quadrants
            var quadrants = new[]
            {
                new Rectangle(0, 0, halfWidth, halfHeight),                     // Top‑Left
                new Rectangle(halfWidth, 0, halfWidth, halfHeight),            // Top‑Right
                new Rectangle(0, halfHeight, halfWidth, halfHeight),           // Bottom‑Left
                new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight)   // Bottom‑Right
            };

            // PNG save options
            var pngOptions = new PngOptions();

            // Save each quadrant as a separate PNG file
            for (int i = 0; i < quadrants.Length; i++)
            {
                string outputPath = Path.Combine(outputDir, $"quadrant_{i + 1}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the specified quadrant
                image.Save(outputPath, pngOptions, quadrants[i]);
            }
        }
    }
}