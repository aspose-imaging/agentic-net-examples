// HOW-TO: Apply Custom 3x3 Edge Detection Kernel to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to highlight object boundaries in a PNG image for computer‑vision preprocessing using Aspose.Imaging in C#.
 * 2. When you want to replace built‑in edge detectors with a custom Laplacian kernel to control the intensity of edge emphasis.
 * 3. When you must process scanned documents and extract sharp edges before OCR to improve text recognition accuracy.
 * 4. When you are building a photo‑editing tool that applies real‑time edge‑enhancement filters to user‑uploaded images in a .NET application.
 * 5. When you need to generate stylized line‑art thumbnails from full‑color PNGs by applying a zero‑sum convolution filter.
 */
