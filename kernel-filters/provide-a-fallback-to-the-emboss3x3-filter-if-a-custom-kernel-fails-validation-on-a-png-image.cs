// HOW-TO: Apply Custom Convolution Kernel with Emboss Fallback on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] customKernel = new double[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
                try
                {
                    var customOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    raster.Filter(raster.Bounds, customOptions);
                }
                catch
                {
                    var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, embossOptions);
                }

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
 * 1. When you need to enhance a PNG image using a specific convolution filter but want a safe fallback if the filter is invalid.
 * 2. When processing user‑uploaded PNGs and must ensure the image is still saved even if a custom kernel fails validation.
 * 3. When building an automated image‑processing pipeline in C# that applies custom sharpening or edge detection and requires a default emboss effect as a backup.
 * 4. When creating a desktop application that lets developers experiment with different convolution matrices on PNG files without crashing the app.
 * 5. When integrating Aspose.Imaging into a .NET service that must gracefully handle malformed filter definitions while preserving the original image format.
 */
