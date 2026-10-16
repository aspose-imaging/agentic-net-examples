// HOW-TO: Check PNG File Size After Applying Emboss Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -2, -1,  0 },
                { -1,  1,  1 },
                {  0,  1,  2 }
            };

            var filterOptions = new ConvolutionFilterOptions(customKernel);

            using (PngImage image = (PngImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, filterOptions);
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long newSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Embossed size: {newSize} bytes");

            if (newSize > originalSize * 1.5)
            {
                Console.WriteLine("Warning: File size increased significantly after emboss filtering.");
            }
            else
            {
                Console.WriteLine("File size increase is within acceptable range.");
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
 * 1. When you need to apply an emboss effect to a PNG image in a .NET application while ensuring the resulting file does not become excessively large.
 * 2. When you want to compare the original and filtered PNG sizes to detect unacceptable growth before uploading to a web service.
 * 3. When you are building an automated image‑processing workflow that must validate that custom convolution filters keep output files within storage limits.
 * 4. When you need to log or display size differences after applying a custom kernel to PNGs for quality‑control reporting.
 * 5. When you are integrating Aspose.Imaging into a C# project to safely apply artistic filters without breaking bandwidth or storage constraints.
 */
