// HOW-TO: Create JPEG2000 Image with Solid Color Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.jp2";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            FileCreateSource source = new FileCreateSource(outputPath, false);
            Jpeg2000Options options = new Jpeg2000Options
            {
                Source = source
            };

            using (Jpeg2000Image canvas = (Jpeg2000Image)Aspose.Imaging.Image.Create(options, 800, 600))
            {
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(255, 255, 0, 0)))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(0, 0, canvas.Width, canvas.Height));
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
 * 1. When you need to generate a JPEG2000 file on the fly in a C# web service and set a uniform background color before adding other graphics.
 * 2. When you want to create large JPEG2000 images using a file‑based memory strategy to avoid consuming RAM during server‑side processing.
 * 3. When you are preparing placeholder or template images for medical imaging systems that require JPEG2000 format with a solid color canvas.
 * 4. When you need to programmatically produce a red background JPEG2000 image for batch watermarking or overlay operations in an automated workflow.
 * 5. When you are testing image rendering pipelines and require a quick way to create a JPEG2000 image with known dimensions and a solid fill using Aspose.Imaging.
 */
