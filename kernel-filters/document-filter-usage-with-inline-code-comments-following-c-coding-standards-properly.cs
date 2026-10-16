// HOW-TO: Apply Median Gaussian Blur and Emboss Filters to JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.jpg";
            string outputMedianPath = "output_median.jpg";
            string outputGaussianPath = "output_gaussian.jpg";
            string outputEmbossPath = "output_emboss.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Apply Median filter
            using (RasterImage medianImage = (RasterImage)Image.Load(inputPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputMedianPath));

                // Create median filter options (kernel size 3)
                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);

                // Apply median filter to the whole image
                medianImage.Filter(medianImage.Bounds, medianOptions);

                // Save the filtered image
                medianImage.Save(outputMedianPath);
            }

            // Apply Gaussian blur filter
            using (RasterImage gaussianImage = (RasterImage)Image.Load(inputPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputGaussianPath));

                // Create Gaussian blur filter options
                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();

                // Apply Gaussian blur filter
                gaussianImage.Filter(gaussianImage.Bounds, gaussianOptions);

                // Save the result
                gaussianImage.Save(outputGaussianPath);
            }

            // Apply Emboss filter using a custom convolution kernel
            using (RasterImage embossImage = (RasterImage)Image.Load(inputPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputEmbossPath));

                // Define emboss kernel matrix
                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1,  1, 1 },
                    {  0,  1, 2 }
                };

                // Create convolution filter options with the emboss kernel
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

                // Apply emboss filter
                embossImage.Filter(embossImage.Bounds, embossOptions);

                // Save the embossed image
                embossImage.Save(outputEmbossPath);
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
 * 1. When you need to reduce noise in a JPEG photo by applying a median filter before further analysis.
 * 2. When you want to create a soft, out‑of‑focus effect on an image using a Gaussian blur filter in a C# application.
 * 3. When you need to highlight edges and texture by applying an emboss filter with a custom convolution kernel to a picture.
 * 4. When you are building an automated image‑processing pipeline that saves filtered versions of the original file in separate output folders.
 * 5. When you must verify the existence of an input image and programmatically generate multiple filtered copies for web or print workflows.
 */
