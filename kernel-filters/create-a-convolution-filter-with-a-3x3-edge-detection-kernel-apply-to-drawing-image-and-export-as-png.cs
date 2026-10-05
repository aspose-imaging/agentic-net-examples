// HOW-TO: Apply 3x3 Edge Detection Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
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
                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1, 8, -1 },
                        { -1, -1, -1 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    var pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to highlight the outlines of a drawing by applying an edge‑detection filter to a PNG file using Aspose.Imaging in C#.
 * 2. When you want to preprocess scanned sketches for OCR by emphasizing edges before further analysis.
 * 3. When you are building a C# application that automatically converts hand‑drawn PNG assets into high‑contrast versions for UI icons.
 * 4. When you must generate stylized thumbnails that show only the contours of images for a gallery preview.
 * 5. When you require a server‑side routine to detect and accentuate edges in user‑uploaded PNG drawings for quality inspection.
 */
