using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
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

                // Apply the convolution filter using the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Prepare PNG save options with a bound source
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image as PNG
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to enhance the details of product photos in PNG format before uploading them to an e‑commerce site, they can apply a custom sharpening kernel with negative coefficients using Aspose.Imaging for .NET.
 * 2. When an automated image‑processing pipeline must improve the readability of scanned PNG documents by emphasizing edges, the convolution filter with a negative‑coefficient kernel provides a fast sharpening step in C#.
 * 3. When a photo‑editing desktop application requires a one‑click “sharpen” feature for PNG images, the code demonstrates how to load, filter, and save the image with Aspose’s RasterImage and ConvolutionFilterOptions.
 * 4. When a batch job processes PNG screenshots from a UI test suite and needs to make UI elements crisper for visual verification, the custom kernel sharpens each image without external tools.
 * 5. When a developer integrates image enhancement into a C# web service that returns sharpened PNG thumbnails, the example shows how to perform the convolution filter and stream the result directly to a file.
 */