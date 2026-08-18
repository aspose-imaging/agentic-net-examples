// HOW-TO: Split a BigTIFF Into Four PNG Quadrants Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\big.tif";
            string outputDir = @"C:\Images\output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(outputDir);

            // Define output file paths for the four quadrants
            string outputPath1 = Path.Combine(outputDir, "quadrant1.png");
            string outputPath2 = Path.Combine(outputDir, "quadrant2.png");
            string outputPath3 = Path.Combine(outputDir, "quadrant3.png");
            string outputPath4 = Path.Combine(outputDir, "quadrant4.png");

            // Ensure the directory for each output file exists (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath4));

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Determine half dimensions
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define the four quadrant rectangles
                var rect1 = new Rectangle(0, 0, halfWidth, halfHeight);                     // Top‑left
                var rect2 = new Rectangle(halfWidth, 0, halfWidth, halfHeight);            // Top‑right
                var rect3 = new Rectangle(0, halfHeight, halfWidth, halfHeight);           // Bottom‑left
                var rect4 = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight);  // Bottom‑right

                // PNG save options (default)
                var pngOptions = new PngOptions();

                // Save each quadrant as a separate PNG file
                image.Save(outputPath1, pngOptions, rect1);
                image.Save(outputPath2, pngOptions, rect2);
                image.Save(outputPath3, pngOptions, rect3);
                image.Save(outputPath4, pngOptions, rect4);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display portions of a very large TIFF on a web map, you can split the BigTIFF into four PNG tiles for faster loading.
 * 2. When a printing workflow requires separate high‑resolution sections of a massive scan, the code extracts each quadrant as an individual PNG file.
 * 3. When a scientific imaging pipeline must analyze different regions of a gigapixel image independently, dividing the BigTIFF into quadrants simplifies region‑based processing.
 * 4. When a mobile app can only handle small images, converting each quadrant of a large TIFF to PNG reduces memory usage and improves performance.
 * 5. When archiving large satellite imagery, saving each quadrant as a compressed PNG enables easier storage management and selective retrieval.
 */
