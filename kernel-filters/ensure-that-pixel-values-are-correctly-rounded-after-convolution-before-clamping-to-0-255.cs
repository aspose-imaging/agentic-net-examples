using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image, apply sharpen filter, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Sharpen filter with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save as PNG
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a C# developer needs to automatically sharpen PNG photos in a batch job, loading the image with Aspose.Imaging, applying a 5×5 sharpen filter with sigma 4.0, rounding the convolution results, clamping pixel values to 0‑255, and saving the result while handling missing files and output directories.
 * 2. When an application processes user‑uploaded images and must improve edge definition before storing them as PNG, using RasterImage.Filter to perform convolution, correctly rounding pixel values, and then clamping them to the valid byte range.
 * 3. When a Windows service generates thumbnails for a gallery and requires a consistent sharpening effect, the code demonstrates how to load any supported raster format, apply a convolution‑based sharpen filter, round the pixel values, and save the enhanced image with PngOptions.
 * 4. When a developer builds a command‑line tool that validates image paths, creates necessary folders, and applies a sharpen filter to ensure the final PNG complies with visual quality standards for web publishing, including proper rounding and clamping of pixel data.
 * 5. When integrating Aspose.Imaging into a .NET Core microservice that receives raw image streams, the example shows how to perform convolution‑based sharpening, correctly round the resulting pixel values, clamp them to 0‑255, and return the processed PNG output.
 */