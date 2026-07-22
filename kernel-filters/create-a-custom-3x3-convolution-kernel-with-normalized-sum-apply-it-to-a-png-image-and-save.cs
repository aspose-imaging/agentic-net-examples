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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel, 1.0, 0));
                PngOptions pngOptions = new PngOptions();
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
 * 1. When a developer wants to enhance the details of a PNG photograph by applying a custom sharpening convolution kernel before publishing it on a website.
 * 2. When an application needs to preprocess scanned PNG documents with a normalized 3×3 filter to improve OCR accuracy by emphasizing text edges.
 * 3. When a game engine loads PNG textures and applies a custom convolution filter to simulate a stylized visual effect such as embossing or edge detection at runtime.
 * 4. When a medical imaging tool processes PNG slices of X‑ray images and uses a normalized convolution kernel to highlight bone structures while preserving overall brightness.
 * 5. When an automated batch job converts a folder of PNG assets, applying a custom 3×3 filter to reduce noise and then saves the results with Aspose.Imaging's PngOptions for downstream analysis.
 */