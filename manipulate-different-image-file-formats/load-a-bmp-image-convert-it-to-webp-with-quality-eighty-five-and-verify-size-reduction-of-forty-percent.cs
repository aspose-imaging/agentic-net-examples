// HOW-TO: Convert BMP to WebP with 85 Quality and Verify 40% Size Reduction in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new WebPOptions
                {
                    Quality = 85
                };
                image.Save(outputPath, options);
            }

            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;
            double reductionPercent = (double)(inputSize - outputSize) / inputSize * 100.0;

            Console.WriteLine($"Input size: {inputSize} bytes");
            Console.WriteLine($"Output size: {outputSize} bytes");
            Console.WriteLine($"Size reduction: {reductionPercent:F2}%");

            if (reductionPercent >= 40.0)
            {
                Console.WriteLine("Reduction meets the 40% requirement.");
            }
            else
            {
                Console.WriteLine("Reduction does not meet the 40% requirement.");
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
 * 1. When you need to shrink large BMP assets for faster web page loading by converting them to WebP at a controlled quality level.
 * 2. When you want to automate batch processing of legacy BMP files into modern WebP format while ensuring at least a 40 % reduction in file size.
 * 3. When you are building a C# image‑optimization pipeline that must validate that the compressed output meets a specific size‑saving threshold before deployment.
 * 4. When you must store screenshots or scanned images in a space‑efficient format without losing too much visual fidelity, using Aspose.Imaging to handle the conversion.
 * 5. When you are preparing images for mobile apps and need to programmatically confirm that the WebP conversion achieves the desired compression ratio.
 */
