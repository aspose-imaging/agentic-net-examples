using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prompt user for Gaussian blur parameters
        Console.Write("Enter radius (positive odd integer): ");
        string radiusInput = Console.ReadLine();
        Console.Write("Enter sigma (positive double): ");
        string sigmaInput = Console.ReadLine();

        if (!int.TryParse(radiusInput, out int radius) || radius <= 0 || radius % 2 == 0)
        {
            Console.Error.WriteLine("Invalid radius. Must be a positive odd integer.");
            return;
        }

        if (!double.TryParse(sigmaInput, out double sigma) || sigma <= 0)
        {
            Console.Error.WriteLine("Invalid sigma. Must be a positive number.");
            return;
        }

        // Load image, apply Gaussian blur with user-defined parameters, and save
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create Gaussian blur filter options with dynamic parameters
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(radius, sigma);

            // Apply filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image
            raster.Save(outputPath);
        }

        Console.WriteLine($"Filtered image saved to: {outputPath}");
    }
}