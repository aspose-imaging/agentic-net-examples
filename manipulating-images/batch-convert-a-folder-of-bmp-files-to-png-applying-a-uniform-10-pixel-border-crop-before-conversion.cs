// HOW-TO: Batch Convert BMP Files to PNG with 10 Pixel Crop in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for cropping
                    using (RasterImage raster = (RasterImage)image)
                    {
                        // Cache data if not already cached
                        if (!raster.IsCached)
                        {
                            raster.CacheData();
                        }

                        // Calculate crop rectangle (10-pixel border)
                        int cropX = 10;
                        int cropY = 10;
                        int cropWidth = raster.Width - 20;
                        int cropHeight = raster.Height - 20;

                        // Ensure dimensions are valid
                        if (cropWidth > 0 && cropHeight > 0)
                        {
                            raster.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));
                        }

                        // Save as PNG with default options
                        raster.Save(outputPath, new PngOptions());
                    }
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to prepare a set of legacy BMP assets for a web site by converting them to PNG and removing a uniform 10‑pixel border around each image.
 * 2. When an automated build pipeline must process scanned documents stored as BMP, trim unwanted edges, and output optimized PNG files for downstream OCR.
 * 3. When a desktop application must migrate user‑generated BMP screenshots to PNG format while consistently cropping the outer margin for a cleaner UI.
 * 4. When a server‑side service has to batch‑process product photos saved as BMP, apply a fixed border crop, and store them as PNG for faster loading on e‑commerce pages.
 * 5. When a migration script needs to read BMP files from a folder, trim a 10‑pixel frame, and save them as PNG using Aspose.Imaging in C# without manual intervention.
 */
