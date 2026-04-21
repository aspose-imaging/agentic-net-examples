using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            // Define custom edge‑detection kernels and their suffixes
            var kernels = new Dictionary<string, double[,]>
            {
                { "horizontal", new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } } }, // Sobel horizontal
                { "vertical",   new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } } }, // Sobel vertical
                { "diag1",      new double[,] { { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } } }, // 45° diagonal
                { "diag2",      new double[,] { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } } }  // 135° diagonal
            };

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string baseName = Path.GetFileNameWithoutExtension(inputPath);

                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size,
                        BackgroundColor = Color.White
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    foreach (var kvp in kernels)
                    {
                        string suffix = kvp.Key;
                        double[,] kernel = kvp.Value;

                        string outputPath = Path.Combine(outputDirectory, $"{baseName}_{suffix}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (var ms = new MemoryStream())
                        {
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                            {
                                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));
                                rasterImage.Save(outputPath, new PngOptions());
                            }
                        }
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