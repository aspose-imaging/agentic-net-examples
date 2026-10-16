// HOW-TO: Apply Custom Convolution Filter to JPEG via Command Line in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<double> coeffs = new List<double>();
            foreach (var a in args)
            {
                if (double.TryParse(a, out double v))
                {
                    coeffs.Add(v);
                }
            }

            int count = coeffs.Count;
            int dim = (int)Math.Sqrt(count);
            if (dim * dim != count || dim == 0)
            {
                Console.Error.WriteLine("Invalid kernel size. Provide N^2 coefficients.");
                return;
            }

            double[,] kernel = new double[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    kernel[i, j] = coeffs[i * dim + j];
                }
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));
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
 * 1. When you need to apply a user‑defined convolution kernel (e.g., edge detection or sharpening) to a JPEG image from a script or batch file.
 * 2. When automating image preprocessing in a CI pipeline and want to pass kernel values as command‑line arguments without writing additional code.
 * 3. When building a lightweight command‑line tool to test different filter coefficients on photos before integrating them into a larger C# application.
 * 4. When processing large numbers of images on a server and require a simple way to apply custom blur or emboss effects using Aspose.Imaging.
 * 5. When creating a reproducible image‑filtering step for scientific data where the exact kernel matrix must be supplied at runtime.
 */
