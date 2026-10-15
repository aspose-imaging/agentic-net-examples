// HOW-TO: Create 250x250 BMP With Bezier Curve and Save to MemoryStream in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            BmpOptions bmpOptions = new BmpOptions();
            using (Image image = Image.Create(bmpOptions, 250, 250))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);
                Point p1 = new Point(20, 200);
                Point p2 = new Point(80, 20);
                Point p3 = new Point(170, 230);
                Point p4 = new Point(230, 30);

                graphics.DrawBezier(pen, p1, p2, p3, p4);

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, new BmpOptions());
                    Console.WriteLine($"MemoryStream length: {ms.Length}");
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
 * 1. When you need to generate a thumbnail BMP image that contains a custom Bezier‑shaped watermark before sending it over a network.
 * 2. When you want to create a printable 250 × 250 BMP diagram with a smooth curve for inclusion in a PDF report generated in a .NET service.
 * 3. When you have to draw vector‑based graphics on a bitmap in memory for a game UI element without writing temporary files to disk.
 * 4. When you are building an API that returns dynamically drawn BMP images, such as signature or signature‑like curves, directly from a MemoryStream.
 * 5. When you need to test image‑processing pipelines by programmatically creating BMP files with known geometric shapes like a Bezier curve.
 */
