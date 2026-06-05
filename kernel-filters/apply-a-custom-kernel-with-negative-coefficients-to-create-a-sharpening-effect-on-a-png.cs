using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom sharpening kernel with negative coefficients
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Create filter options using the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the result as PNG
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
 * 1. When a developer needs to enhance the edge definition of a PNG screenshot for a documentation portal by applying a sharpening filter with a custom convolution kernel.
 * 2. When a C# application must improve the visual clarity of scanned PNG receipts before OCR processing by using negative coefficients in a convolution filter.
 * 3. When a photo‑editing tool built with Aspose.Imaging needs to sharpen PNG product images on the fly to make details more visible in an e‑commerce catalog.
 * 4. When a batch‑processing script has to automatically increase the contrast of PNG map tiles for a GIS web service using a custom kernel in .NET.
 * 5. When a developer wants to programmatically restore the crispness of PNG icons that have become blurry after compression by applying a sharpening convolution filter.
 */