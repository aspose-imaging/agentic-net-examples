using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

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

                // Determine output JPEG path (same file name with .jpg extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Gaussian blur filter with radius 5 and sigma 4.0
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image as JPEG
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
 * 1. When a developer needs to automatically anonymize faces in a large collection of PNG screenshots by applying a Gaussian blur before converting them to JPEGs for web publishing.
 * 2. When a developer wants to preprocess product catalog PNG images with a blur filter to reduce visual noise and then batch‑save them as JPEGs for faster loading on e‑commerce sites.
 * 3. When a developer must generate low‑resolution preview JPEGs from high‑quality PNG assets by applying a blur to hide details while preserving the original aspect ratio.
 * 4. When a developer is required to batch‑process scanned PNG documents, smoothing out scanning artifacts with a blur filter before saving them as JPEGs for archival storage.
 * 5. When a developer needs to create stylized blurred thumbnails from PNG graphics for a mobile app, converting them to JPEG to meet size and performance constraints.
 */