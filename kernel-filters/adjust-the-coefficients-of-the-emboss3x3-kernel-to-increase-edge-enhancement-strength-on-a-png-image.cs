// HOW-TO: Increase Emboss Edge Strength On PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] originalKernel = ConvolutionFilter.Emboss3x3;
                double strengthFactor = 2.0;
                int rows = originalKernel.GetLength(0);
                int cols = originalKernel.GetLength(1);
                double[,] enhancedKernel = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        enhancedKernel[i, j] = originalKernel[i, j] * strengthFactor;
                    }
                }

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(enhancedKernel));

                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to make the details of a PNG photograph stand out by intensifying the emboss effect for a sharper, more three‑dimensional look.
 * 2. When you want to programmatically enhance the edges of scanned documents in a batch process before archiving them as PNG files.
 * 3. When you are building a C# desktop application that applies custom convolution kernels to improve visual contrast in product images.
 * 4. When you need to adjust the strength of an existing emboss filter without creating a new kernel from scratch, using Aspose.Imaging’s built‑in Emboss3x3 matrix.
 * 5. When you are preparing PNG assets for a game or UI and require stronger edge definition to improve readability on high‑resolution displays.
 */
