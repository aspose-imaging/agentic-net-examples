// HOW-TO: Apply User-Defined Gaussian Blur to PNG in C# with Aspose Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

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

            // Prompt user for Gaussian blur parameters
            Console.Write("Enter blur radius (integer > 0): ");
            string radiusInput = Console.ReadLine();
            Console.Write("Enter sigma value (positive double): ");
            string sigmaInput = Console.ReadLine();

            if (!int.TryParse(radiusInput, out int radius) || radius <= 0)
            {
                Console.Error.WriteLine("Invalid radius value.");
                return;
            }

            if (!double.TryParse(sigmaInput, out double sigma) || sigma <= 0)
            {
                Console.Error.WriteLine("Invalid sigma value.");
                return;
            }

            // Load the image and apply the filter
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create Gaussian blur options with user-defined parameters
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(radius, sigma);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }

            Console.WriteLine($"Filtered image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to let end‑users adjust the blur strength of a PNG before saving it in a Windows desktop application.
 * 2. When you want to programmatically apply a custom Gaussian blur with specific radius and sigma values to images for photo‑editing tools.
 * 3. When you must validate user input for blur parameters and ensure the filtered image is saved without errors using Aspose.Imaging.
 * 4. When you are building a batch‑processing utility that lets operators specify different blur settings for each image at runtime.
 * 5. When you require a simple console‑based UI to preview and export Gaussian‑blurred PNGs with dynamically chosen kernel coefficients.
 */
