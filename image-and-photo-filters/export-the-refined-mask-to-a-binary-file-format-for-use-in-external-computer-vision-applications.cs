// HOW-TO: Export PNG Mask to Binary ARGB32 File Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\mask.png";
            string outputPath = "Output\\mask.bin";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage maskImage = (RasterImage)Image.Load(inputPath))
            {
                int width = maskImage.Width;
                int height = maskImage.Height;
                int[] argbPixels = new int[width * height];
                var rect = new Rectangle(0, 0, width, height);
                maskImage.SaveArgb32Pixels(rect, argbPixels);
                byte[] byteData = new byte[argbPixels.Length * 4];
                Buffer.BlockCopy(argbPixels, 0, byteData, 0, byteData.Length);
                File.WriteAllBytes(outputPath, byteData);
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
 * 1. When you need to feed a mask image into a custom computer‑vision algorithm that expects raw ARGB32 bytes.
 * 2. When integrating Aspose.Imaging with a machine‑learning pipeline that reads binary masks for object segmentation.
 * 3. When exporting a PNG annotation mask to a compact binary format for faster network transmission to edge devices.
 * 4. When converting a raster mask to a byte array to store it in a database or binary blob for later retrieval.
 * 5. When preparing training data for a deep‑learning model that requires masks in a plain binary layout rather than PNG files.
 */
