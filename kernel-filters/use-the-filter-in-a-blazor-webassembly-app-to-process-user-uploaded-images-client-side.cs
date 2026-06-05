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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPathGaussian = "output_gaussian.png";
            string outputPathSharpen = "output_sharpen.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathGaussian));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathSharpen));

            // Apply Gaussian blur filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPathGaussian);
            }

            // Apply Sharpen filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                raster.Save(outputPathSharpen);
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
 * 1. When a developer needs to apply a Gaussian blur to a user‑uploaded PNG image in a Blazor WebAssembly app to create a softened preview before saving it locally.
 * 2. When a developer wants to sharpen the details of an uploaded JPEG or PNG picture directly in the browser using Aspose.Imaging’s SharpenFilterOptions to improve readability of scanned documents.
 * 3. When a developer builds a client‑side photo gallery that automatically generates both blurred and sharpened versions of each image for visual effects without sending the files to a server.
 * 4. When a developer prepares images for machine‑learning inference by applying consistent blur or sharpen filters in C# to normalize texture characteristics before uploading them to a cloud service.
 * 5. When a developer creates an online image‑editing tool that lets users compare the original PNG with Gaussian‑blurred and sharpened variants side‑by‑side, using Aspose.Imaging’s RasterImage.Filter method in a Blazor WebAssembly project.
 */