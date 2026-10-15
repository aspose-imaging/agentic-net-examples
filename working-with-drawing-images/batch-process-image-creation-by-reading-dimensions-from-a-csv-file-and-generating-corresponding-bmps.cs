// HOW-TO: Generate Multiple BMP Images from CSV Dimensions Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Globalization;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchBmpGenerator
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string csvPath = "input.csv";
                string outputDirectory = "output";

                // Verify CSV file exists
                if (!File.Exists(csvPath))
                {
                    Console.Error.WriteLine($"File not found: {csvPath}");
                    return;
                }

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Read all lines from CSV
                var lines = File.ReadAllLines(csvPath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Expect format: width,height
                    var parts = line.Split(',');
                    if (parts.Length < 2)
                        continue;

                    if (!int.TryParse(parts[0].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int width) ||
                        !int.TryParse(parts[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int height))
                    {
                        continue;
                    }

                    // Create BMP options
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    // Create image
                    using (var image = Image.Create(bmpOptions, width, height))
                    {
                        // Optional: fill with white background
                        image.Save(Path.Combine(outputDirectory, $"image_{width}x{height}.bmp"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically create placeholder BMP files of specific sizes listed in a CSV for testing UI layouts.
 * 2. When a batch job must produce a set of bitmap assets for a game engine based on dimensions stored in a CSV configuration file.
 * 3. When you want to generate printable thumbnail BMPs for a catalog where the required widths and heights are supplied by a data source.
 * 4. When an automated pipeline has to create blank canvas images for later drawing operations, reading size parameters from a CSV.
 * 5. When you need to pre‑populate a folder with BMP files of various resolutions for performance benchmarking of image‑processing code.
 */
