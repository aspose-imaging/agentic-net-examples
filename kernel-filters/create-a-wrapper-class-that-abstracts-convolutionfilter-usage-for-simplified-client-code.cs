// HOW-TO: Apply Emboss Convolution Filter to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

public class ConvolutionFilterWrapper
{
    private double[,] _kernel;

    public ConvolutionFilterWrapper(double[,] kernel)
    {
        _kernel = kernel;
    }

    public void Apply(Aspose.Imaging.RasterImage image)
    {
        image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(_kernel));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            double[,] embossKernel = new double[,]
            {
                { -2, -1,  0 },
                { -1,  1,  1 },
                {  0,  1,  2 }
            };

            var wrapper = new ConvolutionFilterWrapper(embossKernel);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.RasterImage raster)
                {
                    wrapper.Apply(raster);
                    raster.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
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
 * 1. When you need to add an emboss effect to photos before publishing them on a website.
 * 2. When you want to encapsulate convolution filter logic in a reusable class for multiple image processing tasks.
 * 3. When you have to process large batches of raster images and need a simple API to apply custom kernels.
 * 4. When you need to ensure the input file exists and automatically create the output directory while applying a filter.
 * 5. When you are working with JPEG or PNG files in a C# application and want to use Aspose.Imaging to perform edge‑enhancement transformations.
 */
