using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to soften high‑resolution scanned TIFF documents before publishing them on a website as lightweight PNG files.
 * 2. When an application must automatically reduce noise in medical imaging TIFF files by applying a Gaussian blur with radius five and then store the result in PNG for easy viewing.
 * 3. When a batch‑processing tool converts archival TIFF photographs to PNG thumbnails while applying a Gaussian blur to create a subtle background effect.
 * 4. When a C# service prepares TIFF maps for print by smoothing edges with a Gaussian blur and then saves the processed image as PNG for downstream GIS software.
 * 5. When a document management system needs to obscure sensitive details in a TIFF scan using a Gaussian blur and deliver the blurred version as a PNG to end users.
 */