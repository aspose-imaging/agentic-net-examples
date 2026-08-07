using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Sigma values to test
            double[] sigmas = new double[] { 0.5, 1.5, 2.5 };
            int kernelSize = 5; // Gaussian kernel size (must be odd)

            // Apply Gaussian blur for each sigma
            for (int i = 0; i < sigmas.Length; i++)
            {
                double sigma = sigmas[i];
                string outputPath = $@"C:\Images\sample.GaussianBlur_{sigma}.png";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image, apply filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;
                    var options = new GaussianBlurFilterOptions(kernelSize, sigma);
                    rasterImage.Filter(rasterImage.Bounds, options);
                    rasterImage.Save(outputPath);
                }

                Console.WriteLine($"Saved blurred image (sigma={sigma}) to {outputPath}");
            }

            // Simple comparison: report file sizes for each result
            foreach (double sigma in sigmas)
            {
                string path = $@"C:\Images\sample.GaussianBlur_{sigma}.png";
                if (File.Exists(path))
                {
                    long size = new FileInfo(path).Length;
                    Console.WriteLine($"Sigma {sigma}: file size = {size} bytes");
                }
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
 * 1. When a developer needs to generate multiple blurred PNG versions for responsive web design, they can use Aspose.Imaging for .NET to apply Gaussian blur with sigma values 0.5, 1.5, and 2.5 and compare the resulting file sizes.
 * 2. When testing the visual impact of different Gaussian kernel sigma settings on a raster image, a C# program can load a sample.png, apply GaussianBlurFilterOptions with kernelSize 5 and varying sigma, and save each output for side‑by‑side review.
 * 3. When optimizing image assets for mobile apps, a developer can run this code to create low‑sigma (0.5) and high‑sigma (2.5) blur variants, then use the file‑size report to decide which version balances visual quality and bandwidth.
 * 4. When building an automated preprocessing pipeline that requires consistent blur strength across a batch of images, the loop over sigma values demonstrates how to programmatically apply and store multiple Gaussian blur filters using Aspose.Imaging.
 * 5. When evaluating how different sigma values affect PNG compression ratios, the script’s final size comparison lets a developer quickly see the correlation between blur intensity and output file size in a .NET environment.
 */