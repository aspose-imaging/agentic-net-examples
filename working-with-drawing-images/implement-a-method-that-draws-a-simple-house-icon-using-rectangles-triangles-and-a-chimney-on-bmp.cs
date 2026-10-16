// HOW-TO: Create a Simple House Icon BMP with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("output", "house.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 300;
            int height = 300;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // House base
                Rectangle houseRect = new Rectangle(50, 150, 200, 150);
                using (SolidBrush houseBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(houseBrush, houseRect);
                }
                Pen housePen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(housePen, houseRect);

                // Roof (triangle)
                Point[] roofPoints = new Point[]
                {
                    new Point(50, 150),
                    new Point(250, 150),
                    new Point(150, 80)
                };
                using (SolidBrush roofBrush = new SolidBrush(Color.Brown))
                {
                    graphics.FillPolygon(roofBrush, roofPoints);
                }
                graphics.DrawPolygon(housePen, roofPoints);

                // Chimney
                Rectangle chimneyRect = new Rectangle(180, 50, 30, 30);
                using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkRed))
                {
                    graphics.FillRectangle(chimneyBrush, chimneyRect);
                }
                graphics.DrawRectangle(housePen, chimneyRect);

                // Door
                Rectangle doorRect = new Rectangle(130, 230, 40, 70);
                using (SolidBrush doorBrush = new SolidBrush(Color.SaddleBrown))
                {
                    graphics.FillRectangle(doorBrush, doorRect);
                }
                graphics.DrawRectangle(housePen, doorRect);

                // Windows
                Rectangle leftWindow = new Rectangle(80, 180, 40, 40);
                Rectangle rightWindow = new Rectangle(180, 180, 40, 40);
                using (SolidBrush windowBrush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(windowBrush, leftWindow);
                    graphics.FillRectangle(windowBrush, rightWindow);
                }
                graphics.DrawRectangle(housePen, leftWindow);
                graphics.DrawRectangle(housePen, rightWindow);

                // Save the image (output is already bound)
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
 * 1. When you need to generate a lightweight BMP icon of a house for a real‑time map overlay in a C# desktop application.
 * 2. When you want to programmatically create a simple house illustration for documentation or UI placeholders without using external image files.
 * 3. When you must produce a BMP thumbnail that combines basic geometric shapes (rectangles, polygons) for a property‑listing website.
 * 4. When you are building a game level editor that requires on‑the‑fly drawing of house symbols using Aspose.Imaging’s Graphics API.
 * 5. When you need to automate batch creation of house graphics for printing floor‑plan legends in a .NET reporting tool.
 */
