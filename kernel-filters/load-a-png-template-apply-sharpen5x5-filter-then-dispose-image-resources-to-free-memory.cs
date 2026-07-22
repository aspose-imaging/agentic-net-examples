using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\template.png";
            string outputPath = @"C:\Images\output_sharpened.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Sharpen filter with a 5x5 kernel (size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When generating product catalog thumbnails, a developer can use C# Image.Load to read a PNG template, apply a SharpenFilterOptions(5, 4.0) to enhance details, and save the sharpened PNG for web display.
 * 2. When preparing scanned documents for OCR, a developer can load the PNG file, cast it to RasterImage, apply the 5×5 sharpen filter to improve text legibility, and then dispose the image to free memory.
 * 3. When creating high‑resolution marketing banners, a developer can load a base PNG design, sharpen edges with the 5×5 kernel, save the output PNG, and rely on the using block to automatically release resources.
 * 4. When building a server‑side photo‑editing API, a developer can accept a PNG upload, apply the Sharpen5x5 filter via RasterImage.Filter, and return the processed PNG while ensuring proper disposal of image objects.
 * 5. When automating batch processing of PNG textures for a game, a developer can iterate over files, apply SharpenFilterOptions(5, 4.0) to each image, save the results, and let the using statement clean up memory after each iteration.
 */