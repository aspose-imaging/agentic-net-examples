using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PNG path
        string inputPath = "input.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Define kernel sizes and corresponding sigma values
        int[] kernelSizes = { 3, 5, 7 };
        double[] sigmas = { 1.0, 2.0, 3.0 };

        for (int i = 0; i < kernelSizes.Length; i++)
        {
            // Construct output path for each filtered image
            string outputPath = $"output_gaussian_{kernelSizes[i]}x{kernelSizes[i]}.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image, apply Gaussian blur, and save the result
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(kernelSizes[i], sigmas[i]));
                raster.Save(outputPath);
            }
        }
    }
}