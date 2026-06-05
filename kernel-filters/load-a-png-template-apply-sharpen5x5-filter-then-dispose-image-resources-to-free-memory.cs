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
            string inputPath = "c:\\temp\\template.png";
            string outputPath = "c:\\temp\\output_sharpened.png";

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

                // Apply a 5x5 sharpen filter
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
 * 1. When a developer needs to enhance the visual clarity of a PNG logo before embedding it in a marketing brochure, they can load the template, apply a 5x5 sharpen filter, and save the result.
 * 2. When an e‑commerce platform generates product thumbnails on the fly and wants to improve edge definition of PNG images, this code loads the source, sharpens it, and releases memory.
 * 3. When a desktop publishing tool automatically processes user‑uploaded PNG graphics to make text and line art appear crisper, the Sharpen5x5 filter can be applied as shown.
 * 4. When a batch job prepares PNG assets for a mobile app and must keep memory usage low, the using block ensures the image is loaded, filtered, saved, and disposed efficiently.
 * 5. When a content management system needs to programmatically improve the sharpness of PNG templates used in email newsletters, this C# snippet performs the filter operation and frees resources.
 */