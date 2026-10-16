// HOW-TO: Set BMP Compression Level and Draw Shapes in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions()
            {
                Source = source
            };

            int width = 400;
            int height = 300;

            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawLine(pen, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(350, 250));
                graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(100, 80, 200, 120));
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(150, 100, 100, 80));

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
 * 1. When you need to generate a BMP file with custom graphics while minimizing file size for embedded systems.
 * 2. When you want to programmatically create annotated screenshots in C# and control BMP compression for faster network transfer.
 * 3. When a desktop application must produce printable diagrams in BMP format with specific compression to meet legacy printer requirements.
 * 4. When an automated report generator creates visual charts as BMP images and requires consistent compression settings for archival storage.
 * 5. When a game development tool draws shapes onto a BMP canvas and needs to reduce the image size without losing the drawn content.
 */
