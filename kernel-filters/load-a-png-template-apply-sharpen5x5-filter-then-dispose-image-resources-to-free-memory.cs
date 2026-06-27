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
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a 5x5 sharpen filter (kernel size 5, sigma 4.0)
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
 * 1. When generating product catalog thumbnails, a developer can load a PNG template, sharpen it with a 5×5 filter, and save the enhanced image for clearer display on e‑commerce sites.
 * 2. When preparing scanned documents for OCR, a C# application can load the PNG scan, apply the Sharpen5x5 filter to improve edge contrast, and then release the image memory before further processing.
 * 3. When creating marketing banners that use a PNG background, a developer may sharpen the template to make text and graphics pop, then save the result for use in web ads.
 * 4. When building a desktop photo‑editing tool that offers a “quick sharpen” feature, the code can load the user’s PNG, apply the 5×5 sharpen filter, and dispose the image to keep the application responsive.
 * 5. When automating batch processing of PNG assets for a mobile app, a developer can load each template, apply SharpenFilterOptions(5, 4.0) to enhance visual quality, and free resources after saving to avoid memory leaks.
 */