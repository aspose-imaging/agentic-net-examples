using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply a sharpen filter with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When a web application needs to automatically enhance uploaded PNG photos before displaying them in a gallery, a developer can use this code to apply a sharpen filter with Aspose.Imaging.
 * 2. When a batch processing tool must improve the clarity of scanned PNG documents for OCR accuracy, the code demonstrates how to load, sharpen, and save each image in C#.
 * 3. When an e‑commerce platform wants to boost product image sharpness on the fly to meet visual standards, developers can integrate this snippet to process PNG files server‑side.
 * 4. When a desktop utility converts raw PNG screenshots into sharper versions for presentations, the example shows the necessary file‑system checks, raster image handling, and filter application.
 * 5. When a CI/CD pipeline validates image assets by applying a predefined sharpen filter to PNGs before publishing, this code provides a straightforward C# implementation using Aspose.Imaging.
 */