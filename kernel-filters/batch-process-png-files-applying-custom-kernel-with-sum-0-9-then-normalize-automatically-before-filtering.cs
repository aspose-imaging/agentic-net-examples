// HOW-TO: Batch Apply Custom Convolution Kernel to PNG Images in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_filtered.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    double[,] kernel = new double[,]
                    {
                        { 0.1, 0.1, 0.1 },
                        { 0.1, 0.2, 0.1 },
                        { 0.1, 0.1, 0.0 }
                    };
                    double factor = 1.0 / 0.9; // Normalize kernel sum to 1

                    var filterOptions = new ConvolutionFilterOptions(kernel, factor, 0);
                    raster.Filter(raster.Bounds, filterOptions);

                    using (var options = new PngOptions { Source = new FileCreateSource(outputPath, false) })
                    {
                        raster.Save(outputPath, options);
                    }
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
 * 1. When you need to automatically apply a custom edge‑enhancement convolution filter to a folder of PNG files and save the filtered results.
 * 2. When you must keep image brightness consistent after filtering by normalizing a kernel whose sum is less than one.
 * 3. When you are preparing PNG assets for a machine‑learning pipeline and require the same convolution operation on every image.
 * 4. When you want to generate stylized versions of PNG icons for different UI themes without editing each file manually.
 * 5. When you are building an automated workflow that applies a custom blur or sharpen effect to a batch of PNG graphics in C#.
 */
