using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[3, 3]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                PngOptions options = new PngOptions();
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
 * 1. When a developer needs to automatically highlight object boundaries in uploaded PNG photos for a web‑based image analysis tool, they can generate a 3×3 edge detection kernel at runtime and apply it using Aspose.Imaging’s ConvolutionFilterOptions.
 * 2. When building a C# desktop application that preprocesses scanned documents by emphasizing text edges before OCR, the code can create the kernel dynamically and filter the PNG image to improve character recognition.
 * 3. When creating a batch‑processing pipeline that enhances medical imaging PNG files by detecting tissue edges for visual inspection, the runtime kernel generation allows flexible adjustment without hard‑coding filter values.
 * 4. When implementing a real‑time video‑frame thumbnail generator that extracts sharp edge features from each PNG snapshot, developers can use this snippet to apply the edge detection filter on the fly.
 * 5. When developing an automated quality‑control system that flags blurry PNG product photos, the code can apply the 3×3 edge detection kernel to measure edge contrast and determine image sharpness.
 */