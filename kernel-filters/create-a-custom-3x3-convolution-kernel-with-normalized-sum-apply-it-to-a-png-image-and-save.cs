// HOW-TO: Apply Custom 3x3 Convolution Kernel to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                double factor = 1.0;
                int bias = 0;

                var filterOptions = new ConvolutionFilterOptions(kernel, factor, bias);

                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When you need to enhance edges in a PNG image for computer‑vision preprocessing using Aspose.Imaging in C#.
 * 2. When you want to apply a custom sharpening filter to a PNG before uploading it to a web service.
 * 3. When you must detect outlines in scanned documents by applying a Laplacian kernel with Aspose.Imaging.
 * 4. When you need to programmatically process a batch of PNG files to highlight details for quality‑control inspection.
 * 5. When you are building a C# application that applies user‑defined convolution filters to images and saves the result as PNG.
 */
