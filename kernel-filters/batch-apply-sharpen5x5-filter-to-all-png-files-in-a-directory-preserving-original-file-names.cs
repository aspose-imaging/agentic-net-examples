// HOW-TO: Batch Sharpen PNG Images with 5x5 Filter Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen5x5));

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(filePath));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, options);
                }
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
 * 1. When you need to enhance the sharpness of a large set of PNG photos automatically before publishing them on a website.
 * 2. When you want to apply a 5x5 sharpening convolution to every PNG in a folder while keeping the original filenames for downstream processing.
 * 3. When you are building a preprocessing pipeline that improves the detail of scanned PNG graphics before they are archived.
 * 4. When you must batch‑process product‑catalog PNG assets to make edges clearer without manually editing each file.
 * 5. When you need to integrate a C# routine that reads PNG files, sharpens them, and saves the results to a separate output directory for further analysis.
 */
