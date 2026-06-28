using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Determine quadrant dimensions
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define bounds for each quadrant
                var quadrants = new[]
                {
                    new { Name = "quadrant1.png", Bounds = new Rectangle(0, 0, halfWidth, halfHeight) },                     // Top‑Left
                    new { Name = "quadrant2.png", Bounds = new Rectangle(halfWidth, 0, halfWidth, halfHeight) },            // Top‑Right
                    new { Name = "quadrant3.png", Bounds = new Rectangle(0, halfHeight, halfWidth, halfHeight) },          // Bottom‑Left
                    new { Name = "quadrant4.png", Bounds = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight) }   // Bottom‑Right
                };

                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save each quadrant
                foreach (var q in quadrants)
                {
                    string outputPath = Path.Combine(outputDir, q.Name);
                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the specified region to a PNG file
                    image.Save(outputPath, pngOptions, q.Bounds);
                }
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
 * 1. When a GIS analyst needs to preview sections of a massive satellite BigTIFF raster by extracting four equal quadrants as lightweight PNG thumbnails for a web map.
 * 2. When a medical imaging system must break a high‑resolution pathology slide stored as BigTIFF into four smaller PNG tiles to display on a tablet without loading the full image.
 * 3. When a digital archivist wants to archive portions of a large scanned manuscript by saving each quadrant as separate PNG files for easier metadata tagging.
 * 4. When a printing workflow requires splitting a large‑format advertisement BigTIFF into four printable PNG sections to feed into separate print heads.
 * 5. When a machine‑learning pipeline needs to feed smaller PNG patches from a BigTIFF training image into a model, extracting the four quadrants to increase data diversity.
 */