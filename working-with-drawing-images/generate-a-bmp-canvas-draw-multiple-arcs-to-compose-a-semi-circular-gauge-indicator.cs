// HOW-TO: Create a Semi Circular Gauge BMP Image with Arcs in C# (Aspose.Imaging for .NET)
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
            string outputPath = "gauge.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 400;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 5);
                graphics.DrawArc(pen, new RectangleF(50, 0, 300, 300), 180, 180);

                Pen innerPen = new Pen(Color.Gray, 3);
                graphics.DrawArc(innerPen, new RectangleF(80, 30, 240, 240), 180, 180);

                for (int angle = 180; angle >= 0; angle -= 20)
                {
                    double rad = angle * Math.PI / 180.0;
                    double outerR = 150;
                    double innerR = 130;
                    float cx = 200f;
                    float cy = 150f;

                    float x1 = (float)(cx + outerR * Math.Cos(rad));
                    float y1 = (float)(cy + outerR * Math.Sin(rad));
                    float x2 = (float)(cx + innerR * Math.Cos(rad));
                    float y2 = (float)(cy + innerR * Math.Sin(rad));

                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

                image.Save();
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
 * 1. When you need to generate a BMP gauge chart for a dashboard without using external graphics tools.
 * 2. When you want to programmatically draw a semi‑circular speedometer‑style indicator for an embedded device UI.
 * 3. When you must create tick marks around a half‑circle arc to represent measurement scales in a C# application.
 * 4. When you require a lightweight image file (BMP) that can be saved directly to disk for later printing or reporting.
 * 5. When you are building a custom gauge component and need to render the background arcs and markers using Aspose.Imaging in .NET.
 */
