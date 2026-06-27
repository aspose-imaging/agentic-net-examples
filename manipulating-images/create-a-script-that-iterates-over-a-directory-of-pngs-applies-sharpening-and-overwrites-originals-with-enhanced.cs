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
            // Hardcoded input directory containing PNG files
            string inputDirectory = @"C:\Images\";

            // Get all PNG files in the directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

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

                    // Apply a sharpen filter (kernel size 5, sigma 4.0)
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Ensure the output directory exists (same as input directory)
                    Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                    // Overwrite the original file with the sharpened image
                    rasterImage.Save(inputPath);
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
 * 1. When an e‑commerce platform needs to batch‑sharpen thousands of product PNGs before uploading them to the storefront, this C# script using Aspose.Imaging can automatically enhance and overwrite each image.
 * 2. When a developer is preparing scanned PNG documents for OCR, applying a sharpen filter to the entire folder improves text clarity without manual editing.
 * 3. When technical writers must improve the visual quality of screenshot PNGs for software manuals, this code quickly processes the whole directory and saves the sharpened versions in place.
 * 4. When a medical imaging system stores thumbnail PNGs of scans, running this script ensures each thumbnail is sharpened for better detail visibility before being displayed to clinicians.
 * 5. When a web developer wants to optimize a gallery of PNG assets by applying consistent sharpening across all files, this C# solution iterates through the folder and overwrites the originals with the enhanced images.
 */