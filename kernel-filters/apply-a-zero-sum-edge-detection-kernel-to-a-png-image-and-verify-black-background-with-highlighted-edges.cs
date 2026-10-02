// HOW-TO: Apply Zero‑Sum Edge Detection to PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
                double[,] customKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to highlight object boundaries in a PNG file by applying a convolution edge‑detection filter for computer‑vision preprocessing.
 * 2. When you want to convert a photograph into a black‑background sketch by extracting edges using a zero‑sum kernel in C#.
 * 3. When preparing images for OCR or pattern‑recognition pipelines that require clear edge maps generated with Aspose.Imaging.
 * 4. When generating visual diagnostics to compare original and processed PNGs in a quality‑assurance workflow.
 * 5. When automating batch processing of PNG assets to emphasize contours for UI thumbnails or documentation.
 */
