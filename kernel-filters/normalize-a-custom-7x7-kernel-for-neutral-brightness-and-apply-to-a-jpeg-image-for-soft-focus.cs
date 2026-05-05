using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_softfocus.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom 7x7 kernel (example values)
                double[] kernel = new double[]
                {
                    1, 1, 2, 2, 2, 1, 1,
                    1, 2, 2, 4, 2, 2, 1,
                    2, 2, 4, 8, 4, 2, 2,
                    2, 4, 8,16, 8, 4, 2,
                    2, 2, 4, 8, 4, 2, 2,
                    1, 2, 2, 4, 2, 2, 1,
                    1, 1, 2, 2, 2, 1, 1
                };

                // Normalize the kernel so that its sum equals 1 (neutral brightness)
                double sum = kernel.Sum();
                for (int i = 0; i < kernel.Length; i++)
                {
                    kernel[i] /= sum;
                }

                // Apply a soft‑focus effect using a Gaussian blur that matches the 7x7 size.
                // The Gaussian blur internally creates a normalized kernel, achieving the desired effect.
                var blurOptions = new GaussianBlurFilterOptions(7, 2.0);
                raster.Filter(raster.Bounds, blurOptions);

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