// HOW-TO: Resize JPEG to Maximum Width 1200 Pixels While Keeping Aspect Ratio in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
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

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                int maxWidth = 1200;
                int newWidth = originalWidth;
                int newHeight = originalHeight;

                if (originalWidth > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round((double)originalHeight * maxWidth / originalWidth);
                }

                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
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
 * 1. When you need to generate web‑optimized JPEG thumbnails that never exceed 1200 px wide.
 * 2. When preparing product photos for an e‑commerce site to ensure consistent display across devices.
 * 3. When reducing the file size of high‑resolution camera images before uploading to a cloud storage service.
 * 4. When creating a batch process that resizes user‑uploaded profile pictures to fit a maximum width constraint.
 * 5. When converting large JPEGs into a standard size for inclusion in PDF reports or email newsletters.
 */
