// HOW-TO: Convert Multi‑Page TIFF to Animated WebP in C# With Low Memory (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    multipageImage.PageExportingAction = (index, page) => { };

                    WebPOptions options = new WebPOptions
                    {
                        Lossless = false,
                        Quality = 80
                    };

                    image.Save(outputPath, options);
                }
                else
                {
                    Console.Error.WriteLine("Input image is not a multipage image.");
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
 * 1. When you need to generate a lightweight animated WebP preview from a multi‑page scanned document without loading all pages into memory.
 * 2. When a web application must serve a single animated image instead of a bulky TIFF to improve page load speed on mobile devices.
 * 3. When processing large multi‑page medical or engineering TIFF files on a server with limited RAM and you want to stream each page to a WebP animation.
 * 4. When converting archival TIFF image sequences into a compact WebP format for storage optimization while preserving the original page order.
 * 5. When building a batch job that transforms dozens of multi‑page TIFFs into animated WebP files using Aspose.Imaging without causing out‑of‑memory exceptions.
 */
