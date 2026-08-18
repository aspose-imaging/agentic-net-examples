// HOW-TO: Sharpen TGA Texture With Strength 3 And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter with strength three (size = 3, sigma = 1.0)
                var sharpenOptions = new SharpenFilterOptions(3, 1.0);
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                // Save the result as BMP
                rasterImage.Save(outputPath, new BmpOptions());
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
 * 1. When you need to enhance the details of a game asset stored as a TGA file before converting it to BMP for legacy engine compatibility.
 * 2. When processing textures for a 3D rendering pipeline that requires sharpened images in BMP format for faster loading on older hardware.
 * 3. When preparing UI icons saved as TGA for a Windows desktop application that only supports BMP, and you want to improve their clarity.
 * 4. When batch‑optimizing scanned TGA screenshots by applying a moderate sharpen filter and exporting them as BMP for archival purposes.
 * 5. When integrating an image‑processing step in a C# build script that sharpens TGA textures and outputs BMP files for use in a printing workflow.
 */
