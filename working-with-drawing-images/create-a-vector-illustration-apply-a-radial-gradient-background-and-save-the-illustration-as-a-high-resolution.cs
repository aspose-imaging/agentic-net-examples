// HOW-TO: Create Radial Gradient Vector Illustration and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.tiff";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 2000;
            int height = 2000;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Compression = TiffCompressions.None;
            tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                Graphics graphics = new Graphics(tiffImage);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2;
                int steps = 100;

                for (int i = 0; i < steps; i++)
                {
                    float radius = maxRadius * (steps - i) / (float)steps;
                    byte r = (byte)(255 * i / steps);
                    byte g = (byte)(255 * i / steps);
                    byte b = 255;
                    Color color = Color.FromArgb(255, r, g, b);
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
                    }
                }

                PointF[] starPoints = new PointF[]
                {
                    new PointF(centerX, centerY - 300),
                    new PointF(centerX + 115, centerY - 115),
                    new PointF(centerX + 300, centerY - 100),
                    new PointF(centerX + 150, centerY + 50),
                    new PointF(centerX + 200, centerY + 300),
                    new PointF(centerX, centerY + 150),
                    new PointF(centerX - 200, centerY + 300),
                    new PointF(centerX - 150, centerY + 50),
                    new PointF(centerX - 300, centerY - 100),
                    new PointF(centerX - 115, centerY - 115)
                };

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new PolygonShape(starPoints));
                path.AddFigure(figure);

                Pen pen = new Pen(Color.Black, 5);
                graphics.DrawPath(pen, path);

                tiffImage.Save();
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
 * 1. When you need to generate a scalable vector graphic with a smooth radial gradient background for print‑ready brochures and export it as a 300 DPI TIFF file using C#.
 * 2. When a desktop application must programmatically create high‑resolution background images for product packaging and store them in an uncompressed TIFF format for quality control.
 * 3. When an automated report generator requires a vector‑based illustration with a color‑fade effect that can be saved as a lossless TIFF for archival in a document management system.
 * 4. When a scientific visualization tool needs to render a radial color map as a vector image and output it as a high‑resolution TIFF for inclusion in journal publications.
 * 5. When a web service creates custom greeting‑card designs with gradient graphics and needs to deliver the final artwork as a high‑DPI TIFF for professional printing.
 */
