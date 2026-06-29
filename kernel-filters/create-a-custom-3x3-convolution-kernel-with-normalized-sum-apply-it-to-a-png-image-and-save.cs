using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };
                double factor = 1.0 / 16.0;
                int bias = 0;

                var filterOptions = new ConvolutionFilterOptions(kernel, factor, bias);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
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
 * 1. When a developer needs to reduce visual noise in a PNG photograph by applying a Gaussian‑blur style 3×3 convolution kernel with a normalized sum using Aspose.Imaging in C#.
 * 2. When a developer wants to smooth the edges of scanned PNG documents before performing OCR by filtering the raster image with a custom kernel and saving the processed file.
 * 3. When a developer builds a .NET web service that automatically enhances uploaded PNG avatars with a blur effect through Aspose.Imaging’s ConvolutionFilterOptions and C# file I/O.
 * 4. When a developer must preprocess PNG screenshots for visual‑regression testing by applying a consistent blur to eliminate minor rendering differences across builds.
 * 5. When a developer creates a lightweight image‑preprocessing step that applies a normalized convolution filter to PNG assets to improve visual quality before further image analysis.
 */