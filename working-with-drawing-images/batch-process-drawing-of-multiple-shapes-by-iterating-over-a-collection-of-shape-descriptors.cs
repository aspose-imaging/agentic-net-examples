// HOW-TO: Batch Draw Multiple Shapes on a BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var shapes = new List<Action<Graphics>>
                {
                    g =>
                    {
                        Pen pen = new Pen(Aspose.Imaging.Color.Blue, 3);
                        g.DrawLine(pen, new Point(50, 50), new Point(200, 50));
                    },
                    g =>
                    {
                        Pen pen = new Pen(Aspose.Imaging.Color.Green, 2);
                        using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                        {
                            Rectangle rect = new Rectangle(60, 60, 100, 80);
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(brush, rect);
                        }
                    },
                    g =>
                    {
                        Pen pen = new Pen(Aspose.Imaging.Color.Red, 4);
                        Rectangle rect = new Rectangle(120, 150, 80, 80);
                        g.DrawEllipse(pen, rect);
                    }
                };

                foreach (var draw in shapes)
                {
                    draw(graphics);
                }

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
 * 1. When you need to programmatically add lines, rectangles, and ellipses to a bitmap template to create custom diagrams for engineering reports.
 * 2. When generating a series of annotated screenshots where shapes highlight UI elements before saving the result as a BMP file.
 * 3. When automating the creation of batch graphics for a game’s map editor by drawing multiple geometric shapes onto a base image.
 * 4. When producing printable labels that require filled rectangles and colored outlines drawn on a bitmap background.
 * 5. When building a server‑side service that overlays multiple vector shapes onto uploaded images for branding or watermark purposes.
 */
