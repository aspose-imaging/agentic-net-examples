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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get dynamic filter parameters from the user
            Console.WriteLine("Enter Gaussian blur radius (integer):");
            int radius = int.Parse(Console.ReadLine() ?? "5");

            Console.WriteLine("Enter Gaussian blur sigma (decimal):");
            double sigma = double.Parse(Console.ReadLine() ?? "4.0");

            // Load image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with user‑defined parameters
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(radius, sigma);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the filtered image as PNG
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
 * 1. When a desktop application needs to let users fine‑tune a Gaussian blur effect on PNG photos by entering radius and sigma values before saving the result.
 * 2. When an image‑processing tool must validate the existence of an input file, create the output folder, and apply a user‑defined blur to JPEG or PNG files using Aspose.Imaging.
 * 3. When a photo‑editing software requires real‑time adjustment of blur parameters via a console or UI prompt and then writes the filtered image back to disk in PNG format.
 * 4. When a batch‑processing script needs to load a raster image, apply a custom Gaussian blur filter based on operator input, and preserve image quality with PngOptions.
 * 5. When a C# developer wants to expose a simple UI for non‑technical users to control image smoothing for scanned documents, using Aspose.Imaging’s Filter method and dynamic kernel coefficients.
 */