// HOW-TO: Apply Sharpen Filter With User‑Defined Kernel Size And Sigma In C# (Aspose.Imaging for .NET)
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

            // Get dynamic kernel parameters from the user
            Console.Write("Enter kernel size (odd integer): ");
            string sizeStr = Console.ReadLine();
            Console.Write("Enter sigma (positive number): ");
            string sigmaStr = Console.ReadLine();

            if (!int.TryParse(sizeStr, out int kernelSize) || kernelSize <= 0 || kernelSize % 2 == 0)
            {
                Console.Error.WriteLine("Invalid kernel size.");
                return;
            }

            if (!double.TryParse(sigmaStr, out double sigma) || sigma <= 0)
            {
                Console.Error.WriteLine("Invalid sigma value.");
                return;
            }

            // Load image, apply sharpen filter with user-defined parameters, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(kernelSize, sigma));

                PngOptions options = new PngOptions();
                rasterImage.Save(outputPath, options);
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
 * 1. When a desktop application needs to let users fine‑tune sharpening strength for PNG photos by entering a custom kernel size and sigma.
 * 2. When you want to programmatically enhance scanned documents in C# using Aspose.Imaging while giving end‑users control over the filter parameters.
 * 3. When building a photo‑editing tool that applies a sharpen filter only after validating user‑provided odd kernel dimensions and positive sigma values.
 * 4. When you must ensure the output directory exists and save the processed image with Aspose’s PngOptions after applying a user‑specified filter.
 * 5. When handling image processing errors gracefully in a C# console UI that prompts for filter settings before saving the sharpened result.
 */
