// HOW-TO: Compare JPEG File Sizes After Resizing Images With Different Algorithms In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputFiles = { "input1.png", "input2.png" };
            string outputRoot = "Output";
            Directory.CreateDirectory(outputRoot);

            var resizeTypes = new List<ResizeType>
            {
                ResizeType.NearestNeighbourResample,
                ResizeType.LanczosResample
            };

            int newWidth = 800;
            int newHeight = 600;

            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                var sizeMap = new Dictionary<ResizeType, long>();

                foreach (var rt in resizeTypes)
                {
                    using (Image img = Image.Load(inputPath))
                    {
                        img.Resize(newWidth, newHeight, rt);
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{rt}.jpg";
                        string outputPath = Path.Combine(outputRoot, outputFileName);
                        string outDir = Path.GetDirectoryName(outputPath);
                        Directory.CreateDirectory(outDir ?? ".");

                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 90
                        };
                        img.Save(outputPath, jpegOptions);

                        long size = new FileInfo(outputPath).Length;
                        sizeMap[rt] = size;
                        Console.WriteLine($"{outputFileName}: {size} bytes");
                    }
                }

                if (sizeMap.Count == resizeTypes.Count)
                {
                    var rt1 = resizeTypes[0];
                    var rt2 = resizeTypes[1];
                    long diff = sizeMap[rt2] - sizeMap[rt1];
                    Console.WriteLine($"{Path.GetFileName(inputPath)} size difference ({rt2} - {rt1}): {diff} bytes");
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
 * 1. When you need to generate thumbnails of various sizes and evaluate which resampling algorithm yields the smallest JPEG file for web performance.
 * 2. When you are building an image‑processing pipeline that must choose between nearest‑neighbour and Lanczos resampling to balance quality and bandwidth.
 * 3. When you want to batch‑process a collection of PNG files, resize them to a fixed dimension, and compare the resulting JPEG sizes for storage optimization.
 * 4. When you are testing how different ResizeType settings affect output file size before deciding on a default algorithm for a photo‑gallery application.
 * 5. When you need to programmatically save resized images as JPEG with a specific quality level and log the byte size for each resampling method.
 */
