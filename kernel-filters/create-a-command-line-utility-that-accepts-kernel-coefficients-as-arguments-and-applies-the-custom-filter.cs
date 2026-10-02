// HOW-TO: Apply Custom Convolution Filter to PNG via Command Line in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input\\input.png";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[] coeffs = args.Select(a =>
            {
                double d;
                return double.TryParse(a, out d) ? d : 0.0;
            }).ToArray();

            int length = coeffs.Length;
            int size = (int)Math.Sqrt(length);
            if (size * size != length || size == 0)
            {
                size = 3;
                coeffs = new double[] { 0, -1, 0, -1, 5, -1, 0, -1, 0 };
            }

            double[,] kernel = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] = coeffs[i * size + j];
                }
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new ConvolutionFilterOptions(kernel));
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to sharpen, blur, or detect edges in a PNG image by supplying custom kernel coefficients directly from the command line.
 * 2. When you want to embed a lightweight C# command‑line tool into a build or deployment pipeline to automatically process image assets.
 * 3. When you must apply a specific convolution filter such as emboss or edge detection to a batch of screenshots without using a graphical editor.
 * 4. When you are experimenting with different convolution kernels during image‑processing research and need a quick way to test them via command‑line arguments.
 * 5. When you require a reproducible, scriptable method to apply custom filters to generated graphics in a CI/CD environment.
 */
