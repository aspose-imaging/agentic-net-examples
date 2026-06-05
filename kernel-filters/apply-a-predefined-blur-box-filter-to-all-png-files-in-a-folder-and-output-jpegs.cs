using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

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
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (acts as a blur box filter)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Prepare the output JPEG path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                    // Ensure the output directory exists (unconditional as per rules)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as JPEG
                    var jpegOptions = new JpegOptions();
                    rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to batch‑process product photos stored as PNGs by applying a Gaussian blur box filter and converting them to JPEGs for faster web delivery.
 * 2. When an automated image pipeline must sanitize user‑uploaded screenshots (PNG) with a blur effect to hide sensitive details before archiving them as JPEG files.
 * 3. When a C# application has to generate low‑resolution preview thumbnails from high‑quality PNG assets by blurring and saving them as JPEGs for email newsletters.
 * 4. When a migration script must convert a legacy PNG image library to JPEG format while applying a uniform blur to meet a new design guideline using Aspose.Imaging.
 * 5. When a Windows service processes incoming PNG scans, applies a blur box filter for privacy compliance, and stores the results as JPEGs in a separate output folder.
 */