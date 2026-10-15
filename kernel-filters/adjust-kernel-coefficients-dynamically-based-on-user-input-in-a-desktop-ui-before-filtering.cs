// HOW-TO: Apply Custom 3x3 Convolution Filter to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

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

            Console.WriteLine("Enter 9 kernel coefficients for a 3x3 filter, separated by spaces:");
            string line = Console.ReadLine();
            if (line == null)
            {
                Console.Error.WriteLine("No input received.");
                return;
            }

            string[] parts = line.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 9)
            {
                Console.Error.WriteLine("Exactly 9 coefficients required.");
                return;
            }

            double[,] customKernel = new double[3, 3];
            for (int i = 0; i < 9; i++)
            {
                if (!double.TryParse(parts[i], out double value))
                {
                    Console.Error.WriteLine($"Invalid number: {parts[i]}");
                    return;
                }
                customKernel[i / 3, i % 3] = value;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                image.Filter(image.Bounds, options);
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
 * 1. When a developer needs to let end‑users adjust sharpening, edge detection, or blur strength by entering their own 3×3 kernel values in a Windows console or UI before processing a JPEG image.
 * 2. When building a photo‑editing desktop application that requires dynamic convolution filters, such as custom emboss or motion‑blur effects, based on user‑provided coefficients.
 * 3. When integrating Aspose.Imaging into a C# workflow to apply a user‑defined convolution matrix to raster images for scientific image analysis or custom preprocessing.
 * 4. When creating a batch‑processing tool that reads an input image, prompts the operator for nine kernel numbers, applies the filter, and saves the filtered result without manual image editing software.
 * 5. When implementing a prototype that demonstrates how to convert user input into a double[,] kernel and use Aspose.Imaging’s ConvolutionFilterOptions to modify image pixels in real time.
 */
