// HOW-TO: Recover Corrupted TIFF Using Consistent Recover Mode in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\recovered.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                using (TiffImage tiffImage = (TiffImage)image)
                {
                    int frameCount = tiffImage.Frames.Count();
                    Console.WriteLine($"Recovered TIFF frame count: {frameCount}");
                    int index = 0;
                    foreach (TiffFrame frame in tiffImage.Frames)
                    {
                        Console.WriteLine($"Frame {index}: {frame.Width}x{frame.Height}");
                        index++;
                    }

                    tiffImage.Save(outputPath);
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
 * 1. When a batch of scanned documents stored as multi‑page TIFF files becomes corrupted, you can use this code to recover the images and confirm each page’s dimensions before saving a clean file.
 * 2. When an application receives TIFF images from unreliable sources such as fax machines and needs to automatically restore readable frames without manual intervention, the ConsistentRecover mode can be applied.
 * 3. When you need to validate that a recovered TIFF contains the expected number of frames after a storage failure, the code enumerates and prints each frame’s width and height.
 * 4. When integrating Aspose.Imaging into a C# service that must generate a new TIFF from partially damaged input, this snippet demonstrates loading, recovering, and re‑saving the image.
 * 5. When troubleshooting image‑processing pipelines, you can use this example to test whether the DataBackgroundColor setting correctly fills missing pixel data in recovered TIFF frames.
 */
