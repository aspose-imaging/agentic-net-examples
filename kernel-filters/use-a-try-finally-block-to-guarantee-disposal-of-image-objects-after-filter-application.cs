// HOW-TO: Apply Gaussian Blur to JPEG and Save with Aspose Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.jpg";
        string outputPath = "output/output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When you need to soften a photo before uploading to a website, you can apply a Gaussian blur filter to a JPEG using Aspose.Imaging in C#.
 * 2. When automating batch processing of product images, you can load each JPEG, blur it to hide sensitive details, and save the result programmatically.
 * 3. When creating a preview thumbnail that obscures faces for privacy compliance, you can apply a Gaussian blur to the original image and store the blurred version.
 * 4. When integrating image editing into a desktop application, you can use Aspose.Imaging to load a user‑selected JPEG, apply a blur effect, and write the edited file back to disk.
 * 5. When building a server‑side service that sanitizes uploaded images, you can apply a Gaussian blur filter to the JPEG and ensure resources are released with a try‑finally block.
 */
