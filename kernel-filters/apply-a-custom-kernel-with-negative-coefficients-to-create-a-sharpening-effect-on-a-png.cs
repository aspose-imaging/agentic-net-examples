// HOW-TO: How to Sharpen a PNG Using a Custom Convolution Kernel in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom sharpening kernel with negative coefficients
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG using default options
                PngOptions saveOptions = new PngOptions();
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
 * 1. When you need to enhance the details of product photos in a PNG catalog before uploading them to an e‑commerce site.
 * 2. When you want to programmatically improve the clarity of scanned documents saved as PNGs for better OCR accuracy.
 * 3. When you are building a desktop application that automatically sharpens user‑uploaded PNG avatars to make them look crisper.
 * 4. When you need to preprocess PNG screenshots with a sharpening filter before performing edge detection in a computer‑vision pipeline.
 * 5. When you are migrating legacy image‑processing scripts to C# and require a simple Aspose.Imaging solution to apply a custom kernel for sharpening PNG assets.
 */
