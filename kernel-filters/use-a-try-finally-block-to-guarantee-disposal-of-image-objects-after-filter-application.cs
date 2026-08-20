// HOW-TO: Apply Gaussian Blur to PNG and Ensure Proper Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to programmatically soften a PNG image with a Gaussian blur while guaranteeing that the image objects are released correctly in a C# application.
 * 2. When building an automated batch process that applies a consistent blur effect to uploaded user photos and must avoid memory leaks by disposing of Aspose.Imaging objects.
 * 3. When integrating image preprocessing into a .NET web service that receives PNG files, applies a blur filter for privacy masking, and requires reliable cleanup of resources.
 * 4. When creating a desktop utility that sharpens screenshots by first blurring them for artistic effect, and you want to ensure the file handles are closed even if an error occurs.
 * 5. When developing a CI pipeline that validates image transformations, such as applying a Gaussian blur to test PNG assets, and you need deterministic disposal of the RasterImage to keep the build stable.
 */
