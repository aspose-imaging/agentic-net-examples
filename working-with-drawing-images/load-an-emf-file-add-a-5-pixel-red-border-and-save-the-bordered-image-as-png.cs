// HOW-TO: Add Red 5‑Pixel Border to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output\\bordered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                int border = 5;
                int newWidth = emfImage.Width + border * 2;
                int newHeight = emfImage.Height + border * 2;

                PngOptions pngOptions = new PngOptions();

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(emfImage, new Rectangle(border, border, emfImage.Width, emfImage.Height));

                    Pen redPen = new Pen(Color.Red, border);
                    graphics.DrawRectangle(redPen, new Rectangle(0, 0, newWidth, newHeight));

                    canvas.Save(outputPath, pngOptions);
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
 * 1. When you need to embed a vector EMF logo into a web page with a visible red frame, you can add a 5‑pixel border and export it as a PNG for browser compatibility.
 * 2. When generating printable reports that require highlighted vector diagrams, you can load the EMF, draw a red border, and save the result as a high‑resolution PNG.
 * 3. When converting legacy EMF icons for a Windows desktop application to PNG while emphasizing them with a colored outline, this code adds the border automatically.
 * 4. When creating thumbnails of EMF drawings for a gallery and want each thumbnail to have a consistent red margin, the snippet draws the border and outputs PNG files.
 * 5. When automating a batch process that prepares EMF assets for mobile apps, you can programmatically add a red border and convert them to PNG using Aspose.Imaging in C#.
 */
