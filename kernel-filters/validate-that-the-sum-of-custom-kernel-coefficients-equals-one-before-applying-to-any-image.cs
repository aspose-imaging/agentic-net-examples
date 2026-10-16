// HOW-TO: Validate Convolution Kernel Sum Equals One Before Applying Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            double sum = 0;
            foreach (double value in customKernel)
            {
                sum += value;
            }

            if (Math.Abs(sum - 1.0) > 1e-6)
            {
                Console.Error.WriteLine($"Kernel coefficients sum to {sum}, which is not equal to 1. Filter will not be applied.");
                return;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));
                image.Save(outputPath);
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
 * 1. When you need to ensure a custom 3x3 convolution kernel is normalized before sharpening a JPEG image with Aspose.Imaging in C#.
 * 2. When you want to prevent unintended brightness changes by checking that the sum of kernel coefficients equals one before applying edge‑detection to PNG files.
 * 3. When building an automated image‑processing pipeline that validates kernel weights to avoid runtime errors during batch filtering of TIFF images.
 * 4. When creating a photo‑editing tool that applies user‑defined filters only after confirming the kernel’s total weight is exactly one.
 * 5. When debugging a C# application that uses Aspose.Imaging’s ConvolutionFilterOptions and you need to log a warning if the kernel does not sum to one.
 */
