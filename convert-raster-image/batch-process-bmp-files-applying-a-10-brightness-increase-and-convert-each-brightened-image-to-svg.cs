// HOW-TO: Batch Increase BMP Brightness By 10% And Convert To SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Set up input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files (filter BMP later)
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                // Process only BMP files
                if (!Path.GetExtension(inputPath).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Increase brightness by ~10%
                    RasterImage raster = (RasterImage)image;
                    raster.AdjustBrightness(25); // 10% of 255 ≈ 25

                    // Prepare SVG export options
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to automatically brighten a collection of legacy BMP assets before using them in a modern web application that requires scalable SVG graphics.
 * 2. When you want to preprocess scanned BMP drawings by enhancing their visibility and then convert them to SVG for loss‑less scaling in reports.
 * 3. When a batch of product photos stored as BMP must be lightened slightly and transformed into vector format for inclusion in responsive UI components.
 * 4. When you are migrating an archive of BMP icons, applying a uniform brightness boost to improve contrast, and exporting them as SVG for cross‑platform compatibility.
 * 5. When an automated build pipeline must adjust the brightness of BMP textures and generate SVG versions for use in vector‑based game assets.
 */
