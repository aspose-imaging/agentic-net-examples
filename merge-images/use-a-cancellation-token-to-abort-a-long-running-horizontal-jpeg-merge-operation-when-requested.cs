// HOW-TO: Cancel Long Running Horizontal JPEG Merge With CancellationToken In C# (Aspose.Imaging for .NET)
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
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (imageFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<Size> sizes = new List<Size>();
            foreach (string file in imageFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                var cts = new System.Threading.CancellationTokenSource();
                cts.CancelAfter(System.TimeSpan.FromSeconds(10));
                int offsetX = 0;

                foreach (string file in imageFiles)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation cancelled.");
                        return;
                    }

                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        return;
                    }

                    using (JpegImage img = (JpegImage)Image.Load(file))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                canvas.Save();
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
 * 1. When you need to combine multiple JPEG photos side‑by‑side into a single panoramic image but want to abort the operation if it exceeds a time limit.
 * 2. When building a web API that creates a composite JPEG from user‑uploaded pictures and must enforce a timeout to keep the service responsive.
 * 3. When generating a large horizontal collage of product images for an e‑commerce catalog and require the ability to cancel the merge on user request.
 * 4. When processing batch image merges in a desktop application and want to prevent the UI from freezing by cancelling after a predefined duration.
 * 5. When automating report generation that stitches screenshots into one JPEG and need graceful cancellation in case of resource constraints.
 */
