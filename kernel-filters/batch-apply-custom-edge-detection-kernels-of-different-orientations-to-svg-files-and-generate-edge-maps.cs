// HOW-TO: Batch Apply Custom Edge Detection Kernels to SVG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Set up input and output directories
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

            foreach (string inputPath in files)
            {
                if (!inputPath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);

                // Load SVG and rasterize to PNG bytes in memory
                using (Image vectorImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = vectorImage.Size
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    byte[] pngBytes;
                    using (var ms = new MemoryStream())
                    {
                        vectorImage.Save(ms, pngOptions);
                        pngBytes = ms.ToArray();
                    }

                    // Define edge‑detection kernels
                    var kernels = new Dictionary<string, double[,]>
                    {
                        { "horizontal", new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } } },
                        { "vertical",   new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } } }
                    };

                    foreach (var kvp in kernels)
                    {
                        string orientation = kvp.Key;
                        double[,] kernel = kvp.Value;

                        using (var rasterStream = new MemoryStream(pngBytes))
                        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                        {
                            var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                            rasterImage.Filter(rasterImage.Bounds, convOptions);

                            string outputPath = Path.Combine(outputDirectory, $"{fileName}_{orientation}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            rasterImage.Save(outputPath, new PngOptions());
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

/*
 * Real-World Use Cases:
 * 1. When you need to automatically generate edge‑map PNGs from a collection of SVG icons for use in computer‑vision training datasets.
 * 2. When you want to preprocess vector graphics by applying directional edge‑detection filters before embedding them in a web‑based map visualization.
 * 3. When a CAD workflow requires converting multiple SVG schematics into raster edge images to highlight structural outlines for quality inspection.
 * 4. When you are building a batch image‑processing pipeline that extracts contour information from SVG logos to create stylized thumbnails.
 * 5. When you must integrate custom Sobel‑like kernels with Aspose.Imaging to produce orientation‑specific edge maps from SVG assets in a C# backend service.
 */
