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
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter (radius: 5, sigma: 4.0) to the whole image
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image
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
 * 1. When building a Blazor WebAssembly photo‑editing tool that lets users upload PNG files and instantly apply a Gaussian blur filter before saving the result locally.
 * 2. When creating an online form that requires users to submit a blurred version of their ID image for privacy, using Aspose.Imaging to process the image entirely in the browser.
 * 3. When developing a client‑side image‑optimization pipeline that reduces visual detail with a Gaussian blur to lower file size of uploaded JPEG or PNG pictures before sending them to a server.
 * 4. When implementing a preview feature in a Blazor app that shows a real‑time blurred thumbnail of any user‑selected image to help users decide if they want to keep the original.
 * 5. When adding a custom filter option to a Blazor‑based e‑commerce product‑gallery, allowing sellers to upload product photos and automatically apply a subtle blur effect to background areas using RasterImage filtering.
 */