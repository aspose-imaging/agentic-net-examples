using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

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

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);
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
 * 1. When a developer needs to automatically blur sensitive information in PNG screenshots before storing them in a secure archive, they can use the wrapper to apply a Gaussian blur filter with a single method call.
 * 2. When building a C# web service that generates thumbnail previews of uploaded PNG files and wants to smooth edges for a professional look, the wrapper simplifies applying the convolution filter.
 * 3. When creating a batch image processing tool that prepares product photos by reducing noise in PNG images, the wrapper abstracts the Aspose.Imaging filter options for easy integration.
 * 4. When implementing a desktop application that applies artistic effects such as soft focus to user‑selected PNG images, the wrapper lets developers invoke the Gaussian blur without handling low‑level raster operations.
 * 5. When integrating image preprocessing into a machine‑learning pipeline that requires blurred PNG inputs to augment training data, the wrapper provides a concise API to apply the convolution filter across many files.
 */