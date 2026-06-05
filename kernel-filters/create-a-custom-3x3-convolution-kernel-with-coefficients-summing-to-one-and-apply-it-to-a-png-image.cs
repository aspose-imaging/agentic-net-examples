using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // 3x3 kernel with coefficients summing to 1
                double[,] kernel = new double[,]
                {
                    { 0.0, 0.2, 0.0 },
                    { 0.2, 0.2, 0.2 },
                    { 0.0, 0.2, 0.0 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                raster.Save(outputPath);
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
 * 1. When a developer needs to apply a custom smoothing filter to a PNG image in a C# application using Aspose.Imaging for .NET, they can create a 3x3 convolution kernel with coefficients that sum to one and process the raster image.
 * 2. When building an automated image preprocessing pipeline that requires consistent brightness preservation while reducing noise in PNG files, a developer can use the provided code to apply a normalized 3x3 convolution filter with Aspose.Imaging.
 * 3. When implementing a real‑time photo editing feature that lets users apply lightweight blur effects without changing the overall image intensity, the code demonstrates how to define and apply a custom convolution kernel in C#.
 * 4. When migrating legacy image processing scripts to a .NET environment, a developer can replace hand‑rolled pixel loops with Aspose.Imaging’s ConvolutionFilterOptions to efficiently apply a 3x3 kernel to PNG assets.
 * 5. When creating a batch job that processes a folder of PNG graphics and needs a reproducible, normalized filter for visual consistency, the example shows how to load each image, apply the kernel, and save the result using Aspose.Imaging for .NET.
 */