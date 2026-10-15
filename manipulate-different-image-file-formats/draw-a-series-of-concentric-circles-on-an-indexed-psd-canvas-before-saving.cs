// HOW-TO: Create Concentric Circles on Indexed PSD Canvas Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = new Aspose.Imaging.ColorPalette(new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Black,
                Aspose.Imaging.Color.White,
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue
            });

            int width = 500;
            int height = 500;

            using (var image = Aspose.Imaging.Image.Create(options, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20;
                Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green,
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.Black,
                    Aspose.Imaging.Color.White
                };
                int colorIndex = 0;

                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    int diameter = radius * 2;
                    int x = centerX - radius;
                    int y = centerY - radius;
                    var pen = new Aspose.Imaging.Pen(colors[colorIndex % colors.Length], 1);
                    graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(x, y, diameter, diameter));
                    colorIndex++;
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
 * 1. When you need to generate a layered PSD file with a simple indexed‑color pattern of rings for a design mock‑up or automated asset pipeline.
 * 2. When an application must produce printable artwork that uses a limited palette and requires precise geometric shapes such as concentric circles in a Photoshop‑compatible file.
 * 3. When you are building a batch process that creates thumbnail‑style PSD previews with colored rings to illustrate color‑palette usage in a digital asset management system.
 * 4. When a game‑development tool needs to export level‑design markers as indexed PSD images with concentric circles for easy editing in Photoshop.
 * 5. When a reporting service has to generate PSD charts composed of concentric circles using a predefined palette for branding consistency.
 */
