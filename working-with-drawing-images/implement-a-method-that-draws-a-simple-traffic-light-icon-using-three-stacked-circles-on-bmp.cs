// HOW-TO: Create a BMP Traffic Light Icon with Stacked Circles in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/traffic_light.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int circleRadius = 30;
            int circleDiameter = circleRadius * 2;
            int spacing = 10;
            int width = 80;
            int height = (circleDiameter * 3) + (spacing * 2) + 20; // extra padding

            // Create BMP image bound to output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Black);

                // Draw traffic light housing
                using (SolidBrush housingBrush = new SolidBrush(Color.DarkGray))
                {
                    graphics.FillRectangle(housingBrush, new Rectangle(10, 10, width - 20, height - 20));
                }

                // Pen for circle outlines
                Pen outlinePen = new Pen(Color.Black, 2);

                // Positions for circles
                int startX = (width / 2) - circleRadius;
                int startY = 20;

                // Red light
                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    Rectangle redRect = new Rectangle(startX, startY, circleDiameter, circleDiameter);
                    graphics.FillEllipse(redBrush, redRect);
                    graphics.DrawEllipse(outlinePen, redRect);
                }

                // Yellow light
                using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
                {
                    Rectangle yellowRect = new Rectangle(startX, startY + circleDiameter + spacing, circleDiameter, circleDiameter);
                    graphics.FillEllipse(yellowBrush, yellowRect);
                    graphics.DrawEllipse(outlinePen, yellowRect);
                }

                // Green light
                using (SolidBrush greenBrush = new SolidBrush(Color.Lime))
                {
                    Rectangle greenRect = new Rectangle(startX, startY + (circleDiameter + spacing) * 2, circleDiameter, circleDiameter);
                    graphics.FillEllipse(greenBrush, greenRect);
                    graphics.DrawEllipse(outlinePen, greenRect);
                }

                // Save the image (output already bound)
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
 * 1. When you need to programmatically generate a simple traffic‑light BMP image for a dashboard or simulation without relying on pre‑made assets.
 * 2. When you want to create a custom icon that can be saved as a BMP file and used in legacy Windows applications or shortcuts.
 * 3. When you require a lightweight, three‑circle traffic signal graphic for printing or low‑resolution displays in a .NET project.
 * 4. When you are teaching or learning how to draw shapes, fill brushes, and use pens with Aspose.Imaging in C#.
 * 5. When you must produce a traffic‑light symbol on the fly for automated reports, status monitors, or IoT device visualizations.
 */
