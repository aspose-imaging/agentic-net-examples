// HOW-TO: Apply Multiple Gaussian Blur Filters with Different Sigma Values in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            double[] sigmas = new double[] { 0.5, 1.5, 2.5 };
            foreach (double sigma in sigmas)
            {
                string fileName = $"output_sigma_{sigma.ToString().Replace('.', '_')}.jpg";
                string outputPath = Path.Combine(outputDir, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(3, sigma);
                    image.Filter(image.Bounds, filterOptions);
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate preview images with varying levels of softness for a photo gallery, you can apply Gaussian blur with sigma 0.5, 1.5, and 2.5 and save each result as a JPEG.
 * 2. When testing the visual impact of different blur intensities on a product image before choosing a final effect, this code lets you compare three sigma values side by side.
 * 3. When creating a set of blurred background layers for a UI design, you can automatically produce multiple JPEG files with different blur strengths using Aspose.Imaging in C#.
 * 4. When evaluating performance of the GaussianBlurFilterOptions in Aspose.Imaging, the loop over several sigma values provides a quick benchmark across small, medium, and strong blur.
 * 5. When preparing images for a machine‑learning dataset that requires varied blur levels to augment training data, the script generates the required JPEG samples with three sigma settings.
 */
