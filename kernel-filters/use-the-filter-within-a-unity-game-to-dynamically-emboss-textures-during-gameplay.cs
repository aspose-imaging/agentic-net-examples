// HOW-TO: Apply Custom Emboss Convolution Filter to PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -2, -1, 0 },
                { -1, 1, 1 },
                { 0, 1, 2 }
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new ConvolutionFilterOptions(customKernel));
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
 * 1. When you need to add a real‑time emboss effect to player‑generated PNG textures in a Unity game using C# and Aspose.Imaging.
 * 2. When you want to preprocess imported sprite sheets by applying a custom convolution kernel to enhance depth before saving them as PNG files.
 * 3. When a mobile app requires on‑the‑fly edge‑enhancement of user‑uploaded images without external libraries, leveraging Aspose.Imaging’s ConvolutionFilterOptions.
 * 4. When an automated build pipeline must generate stylized PNG assets by applying a programmable emboss filter written in C#.
 * 5. When a server‑side service processes uploaded PNGs to create a raised‑relief preview for e‑commerce product images using a custom kernel.
 */
