// HOW-TO: Apply Normalized Convolution Kernel to PNG Image with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }
            };

            double sum = kernel.Cast<double>().Sum();
            if (sum != 0)
            {
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var filterOptions = new ConvolutionFilterOptions(kernel, factor: 1.0, bias: 0);
                raster.Filter(raster.Bounds, filterOptions);
                var pngOptions = new PngOptions();
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
 * 1. When you need to blur a PNG template uniformly by applying a Gaussian‑style kernel before generating final graphics.
 * 2. When you must ensure a custom filter kernel sums to one to preserve image brightness during convolution.
 * 3. When you want to programmatically apply a sharpening or smoothing effect to a PNG in a .NET service without external libraries.
 * 4. When you need to preprocess PNG assets for web or print by applying a normalized filter and saving the result automatically.
 * 5. When you are building an image‑processing pipeline that loads a template, applies a custom convolution filter, and stores the output as a PNG file.
 */
