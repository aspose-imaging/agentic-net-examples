// HOW-TO: Apply Custom Sharpening Kernel to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to enhance the details of a PNG photograph in a .NET application without using external libraries, you can apply a custom sharpening kernel with Aspose.Imaging.
 * 2. When processing scanned documents where edges appear blurry, the code sharpens the image by convolving a negative‑coefficient kernel, improving OCR accuracy.
 * 3. When generating thumbnails for a web gallery and want each PNG to look crisp, you can use the convolution filter to boost contrast around edges.
 * 4. When building an automated image‑processing pipeline that must preserve PNG transparency while sharpening, this approach keeps the alpha channel intact.
 * 5. When creating a batch job that reads PNG files, applies a user‑defined sharpening mask, and saves the results to a specific folder, the example shows the complete workflow.
 */
