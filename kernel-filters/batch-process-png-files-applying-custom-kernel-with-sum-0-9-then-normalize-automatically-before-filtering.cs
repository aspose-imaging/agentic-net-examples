// HOW-TO: Batch Apply Custom Convolution Kernel To PNG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
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

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_filtered.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    double[,] kernel = new double[,]
                    {
                        { 0, -0.1, 0 },
                        { -0.1, 1.3, -0.1 },
                        { 0, -0.1, 0 }
                    };

                    var filterOptions = new ConvolutionFilterOptions(kernel);

                    raster.Filter(raster.Bounds, filterOptions);

                    var options = new PngOptions
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
 * 1. When you need to sharpen a collection of PNG photos automatically before uploading them to a web gallery.
 * 2. When you want to reduce noise in scanned PNG documents by applying a custom edge‑enhancing kernel across all files in a folder.
 * 3. When you must preprocess PNG assets for a game engine, applying a specific convolution filter and saving the results with a consistent naming scheme.
 * 4. When you are building a server‑side service that normalizes image intensity and applies a custom filter to every PNG uploaded by users.
 * 5. When you need to batch‑convert PNG screenshots to a filtered version for visual analysis without manually editing each file.
 */
