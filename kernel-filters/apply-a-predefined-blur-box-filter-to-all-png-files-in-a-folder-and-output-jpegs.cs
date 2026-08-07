using System;
using System.IO;
using Aspose.Imaging;
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

                // Determine the output JPEG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists (covers subfolders if any)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering capabilities
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (used here as a blur box filter)
                    // Radius = 5, Sigma = 4.0 (adjust as needed)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image as JPEG
                    rasterImage.Save(outputPath);
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
 * 1. When a developer needs to batch‑blur confidential PNG screenshots before archiving them as smaller JPEG files for compliance reporting.
 * 2. When an e‑commerce platform wants to automatically apply a soft blur to product PNG overlays and store the result as JPEG thumbnails for faster page loads.
 * 3. When a photo‑sharing app must convert user‑uploaded PNG avatars to blurred JPEG previews to protect privacy while reducing bandwidth usage.
 * 4. When a digital marketing team requires a C# script that processes a folder of PNG banner images, adds a Gaussian blur effect, and saves them as JPEGs for email campaigns.
 * 5. When a document management system needs to programmatically apply a blur box filter to scanned PNG pages and output JPEGs for OCR preprocessing.
 */