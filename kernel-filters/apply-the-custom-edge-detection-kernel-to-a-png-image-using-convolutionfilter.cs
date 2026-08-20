// HOW-TO: Apply Custom Edge Detection Kernel to PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel, 1.0, 0));

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
 * 1. When you need to highlight object boundaries in a PNG before performing OCR or pattern recognition.
 * 2. When you want to generate stylized edge‑enhanced thumbnails for a web gallery using C#.
 * 3. When preprocessing medical scan images to emphasize edges for diagnostic analysis in a .NET application.
 * 4. When creating a custom filter pipeline that applies a Laplacian kernel to PNG assets for computer‑vision training data.
 * 5. When automating batch processing of product photos to detect defects by accentuating edges with Aspose.Imaging.
 */
