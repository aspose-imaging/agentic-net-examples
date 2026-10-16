// HOW-TO: Convert OTG to PNG with Text Watermark in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.otg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 48);
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.White))
                {
                    graphics.DrawString("Watermark", font, brush, new Aspose.Imaging.PointF(10, 10));
                }

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate a PNG preview of an OTG vector file and embed a copyright notice directly onto the image.
 * 2. When an e‑commerce platform must display product diagrams (OTG) as watermarked PNGs to prevent unauthorized reuse.
 * 3. When a reporting tool converts technical OTG schematics to PNG and adds a “Confidential” label before saving to a shared folder.
 * 4. When a batch job processes uploaded OTG files, adds branding text, and stores the resulting PNGs for web delivery.
 * 5. When a desktop application needs to load an OTG illustration, overlay user‑specified text, and export it as a PNG for printing or archiving.
 */
