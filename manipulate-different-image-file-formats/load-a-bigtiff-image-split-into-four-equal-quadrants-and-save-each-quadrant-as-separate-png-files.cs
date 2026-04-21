using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\bigimage.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define bounds for the four quadrants
                var quadrants = new[]
                {
                    new { Name = "quadrant1.png", Bounds = new Rectangle(0, 0, halfWidth, halfHeight) },                     // Top‑Left
                    new { Name = "quadrant2.png", Bounds = new Rectangle(halfWidth, 0, halfWidth, halfHeight) },            // Top‑Right
                    new { Name = "quadrant3.png", Bounds = new Rectangle(0, halfHeight, halfWidth, halfHeight) },          // Bottom‑Left
                    new { Name = "quadrant4.png", Bounds = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight) }   // Bottom‑Right
                };

                // Output directory
                string outputDir = @"C:\Images\output";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDir);

                // PNG save options
                var pngOptions = new PngOptions();

                // Save each quadrant
                foreach (var q in quadrants)
                {
                    string outputPath = Path.Combine(outputDir, q.Name);

                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the specified rectangle as a PNG file
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