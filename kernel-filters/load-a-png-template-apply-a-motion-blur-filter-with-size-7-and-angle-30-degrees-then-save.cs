using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(7, 1.0, 30.0));
                raster.Save(outputPath);
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
 * 1. When a developer wants to add a subtle motion blur effect to a PNG logo before embedding it in a marketing email.
 * 2. When an e‑commerce site needs to generate product thumbnails with a directional blur to simulate movement in a promotional banner.
 * 3. When a game UI designer applies a motion‑wiener filter to a PNG button image to create a dynamic hover effect.
 * 4. When a photo‑editing application programmatically processes user‑uploaded PNG files and saves the blurred result to an output folder.
 * 5. When an automated report generator adds a motion‑blurred PNG watermark to highlight a specific section of a PDF export.
 */