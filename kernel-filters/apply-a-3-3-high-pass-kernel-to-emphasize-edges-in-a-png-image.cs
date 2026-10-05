// HOW-TO: Apply High Pass Edge Filter to PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            };

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));
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
 * 1. When you want to emphasize edges in a PNG diagram by applying a high‑pass convolution filter with Aspose.Imaging in C#.
 * 2. When preparing PNG assets for computer‑vision models that require edge‑enhanced images before feature extraction.
 * 3. When generating sharpened PNG thumbnails for a web gallery where fine details need to be more visible.
 * 4. When preprocessing scanned PNG documents for OCR by increasing contrast around text edges using a high‑pass kernel.
 * 5. When automating a batch process that applies an edge‑detecting filter to multiple PNG files and saves the results with Aspose.Imaging.
 */
