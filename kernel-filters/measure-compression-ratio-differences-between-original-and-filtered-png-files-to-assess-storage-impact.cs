// HOW-TO: Measure PNG Compression Ratio After Applying Adaptive Filter In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string filteredPath = "output/filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                options.FilterType = PngFilterType.Adaptive;
                image.Save(filteredPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long filteredSize = new FileInfo(filteredPath).Length;
            double compressionRatio = (double)filteredSize / originalSize;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Filtered size: {filteredSize} bytes");
            Console.WriteLine($"Compression ratio (filtered/original): {compressionRatio:P2}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compare the original and filtered PNG file sizes to determine storage savings after applying an adaptive filter.
 * 2. When optimizing images for web use and want to quantify how much bandwidth is reduced by the adaptive PNG filter.
 * 3. When building an automated pipeline that logs compression statistics for PNG assets in a content management system.
 * 4. When evaluating different PNG filter types to select the most efficient one for a large image library.
 * 5. When troubleshooting why a PNG file size did not decrease after processing and need to see the exact compression ratio.
 */
