// HOW-TO: Apply Emboss 3x3 Filter to PNG Image and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = ConvolutionFilter.Emboss3x3;
                var options = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, options);

                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to programmatically add a 3‑x‑3 emboss effect to PNG files before displaying them in a .NET desktop application.
 * 2. When you want to process user‑uploaded images on a server, apply a convolution filter, and store the result as a compressed PNG without manual editing.
 * 3. When you are building an automated image‑processing pipeline that must enhance texture details using the Emboss3x3 kernel in C#.
 * 4. When you need to integrate Aspose.Imaging’s convolution filter into a batch job that reads images, applies the emboss effect, and writes the output to a specific folder.
 * 5. When you are creating a photo‑editing feature that programmatically modifies raster images with a 3×3 emboss matrix and saves the edited version in PNG format.
 */
