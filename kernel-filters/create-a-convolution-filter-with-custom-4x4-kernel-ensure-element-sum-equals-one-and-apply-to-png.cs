using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[4, 4]
                {
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1, 0);
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
 * 1. When a developer wants to apply a uniform blur to a PNG image by using a custom 4x4 convolution kernel whose elements sum to one, they can use this code.
 * 2. When an application needs to preprocess scanned PNG documents to reduce noise before OCR by applying a normalized averaging filter, this example shows how to do it in C# with Aspose.Imaging.
 * 3. When a game asset pipeline requires consistent smoothing of PNG textures across different resolutions, the code demonstrates how to implement a custom convolution filter in .NET.
 * 4. When a web service must generate a softened thumbnail from a user‑uploaded PNG file, the sample illustrates loading, filtering, and saving the result with Aspose.Imaging.
 * 5. When a developer is building an image‑editing tool that lets users apply custom kernels for effects such as motion blur or edge detection, this snippet provides the basic steps for applying a 4x4 kernel to a PNG image.
 */