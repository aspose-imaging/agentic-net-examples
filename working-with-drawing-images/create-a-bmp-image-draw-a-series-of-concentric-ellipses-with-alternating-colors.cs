// HOW-TO: Create BMP with Concentric Red and Blue Ellipses in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int maxRadius = Math.Min(width, height) / 2;
                int ellipsesCount = 10;
                int step = maxRadius / ellipsesCount;

                for (int i = 0; i < ellipsesCount; i++)
                {
                    int radius = maxRadius - i * step;
                    int x = (width / 2) - radius;
                    int y = (height / 2) - radius;
                    int ellipseWidth = radius * 2;
                    int ellipseHeight = radius * 2;

                    Aspose.Imaging.Color color = (i % 2 == 0) ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Pen pen = new Pen(color, 3);
                    graphics.DrawEllipse(pen, x, y, ellipseWidth, ellipseHeight);
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
 * 1. When you need to programmatically generate a BMP image containing concentric ellipses for a custom chart or decorative background in a C# application.
 * 2. When you want to create a test image with alternating red and blue rings to verify color handling and pen thickness in Aspose.Imaging rendering.
 * 3. When you are building a reporting tool that embeds a patterned BMP signature or watermark composed of layered ellipses.
 * 4. When you need to produce a simple geometric illustration for documentation or tutorials that demonstrates drawing shapes with the Aspose.Imaging Graphics class.
 * 5. When you are automating the creation of placeholder graphics for UI mockups where a BMP with centered ellipses serves as a visual guide.
 */
