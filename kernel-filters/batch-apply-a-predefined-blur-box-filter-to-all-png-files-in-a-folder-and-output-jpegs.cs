using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "C:\\Images\\Input";
            string outputFolder = "C:\\Images\\Output";

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Input folder not found: {inputFolder}");
                return;
            }

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filter
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (predefined blur box filter)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Build output path with .jpg extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as JPEG with default options
                    rasterImage.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to batch‑process a directory of PNG product photos and generate blurred JPEG thumbnails for faster loading on an e‑commerce website.
 * 2. When a C# application must convert scanned PNG documents into JPEG format while applying a Gaussian blur to protect sensitive information before archiving.
 * 3. When an automated build script has to create low‑resolution, blurred preview images from PNG assets for a mobile app’s asset pipeline using Aspose.Imaging.
 * 4. When a photo‑management tool requires converting user‑uploaded PNG images to JPEG with a predefined blur box filter to meet a specific visual style guideline.
 * 5. When a server‑side service processes PNG logos in bulk, applies a Gaussian blur for branding consistency, and saves the results as JPEGs for downstream marketing workflows.
 */