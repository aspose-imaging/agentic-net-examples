// HOW-TO: Create BMP Image With Random Colored Lines In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\random_lines.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Random rand = new Random();
                int lineCount = 20;

                for (int i = 0; i < lineCount; i++)
                {
                    int x1 = rand.Next(width);
                    int y1 = rand.Next(height);
                    int x2 = rand.Next(width);
                    int y2 = rand.Next(height);
                    Color lineColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    Pen pen = new Pen(lineColor, 1);
                    graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
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
 * 1. When you need to generate a simple BMP placeholder with random line art for testing image rendering pipelines.
 * 2. When you want to programmatically create a white‑background bitmap and draw colorful lines for visualizing random data patterns.
 * 3. When you need to produce a lightweight BMP file for UI mockups that includes dynamic, randomly colored line graphics.
 * 4. When you are building a graphics benchmark that requires drawing multiple random lines on a bitmap to measure drawing performance.
 * 5. When you need to generate sample BMP assets for documentation or tutorials that demonstrate basic drawing operations with Aspose.Imaging in C#.
 */
