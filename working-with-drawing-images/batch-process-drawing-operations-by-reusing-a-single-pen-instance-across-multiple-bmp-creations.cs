// HOW-TO: Reuse a Single Pen to Draw Multiple BMP Images in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output folder
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            // Reusable Pen
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);

            // Canvas size
            int canvasWidth = 200;
            int canvasHeight = 200;

            // First BMP
            string outputPath1 = Path.Combine(outputFolder, "image1.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            BmpOptions bmpOptions1 = new BmpOptions();
            bmpOptions1.Source = new FileCreateSource(outputPath1, false);
            using (Image image1 = Image.Create(bmpOptions1, canvasWidth, canvasHeight))
            {
                Graphics graphics = new Graphics(image1);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawLine(pen, 10, 10, canvasWidth - 10, 10);
                image1.Save();
            }

            // Second BMP
            string outputPath2 = Path.Combine(outputFolder, "image2.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));
            BmpOptions bmpOptions2 = new BmpOptions();
            bmpOptions2.Source = new FileCreateSource(outputPath2, false);
            using (Image image2 = Image.Create(bmpOptions2, canvasWidth, canvasHeight))
            {
                Graphics graphics = new Graphics(image2);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawLine(pen, 10, 20, canvasWidth - 10, 20);
                image2.Save();
            }

            // Third BMP
            string outputPath3 = Path.Combine(outputFolder, "image3.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
            BmpOptions bmpOptions3 = new BmpOptions();
            bmpOptions3.Source = new FileCreateSource(outputPath3, false);
            using (Image image3 = Image.Create(bmpOptions3, canvasWidth, canvasHeight))
            {
                Graphics graphics = new Graphics(image3);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawLine(pen, 10, 30, canvasWidth - 10, 30);
                image3.Save();
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
 * 1. When you need to generate a series of BMP files with identical line styles, reusing one Pen object reduces memory overhead and improves performance.
 * 2. When creating template‑based graphics such as report headers or watermarks across many images, a shared Pen ensures consistent color and thickness.
 * 3. When automating batch processing of engineering diagrams where each diagram uses the same line attributes, the code lets you draw lines on multiple canvases without recreating the Pen.
 * 4. When building a thumbnail generator that adds uniform borders or guides to several BMP thumbnails, reusing the Pen simplifies the drawing loop.
 * 5. When developing a game asset pipeline that produces multiple sprite frames with the same outline style, the reusable Pen streamlines the creation of each frame.
 */
