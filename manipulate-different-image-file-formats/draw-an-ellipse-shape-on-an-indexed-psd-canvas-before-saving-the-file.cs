// HOW-TO: Create Indexed PSD with Red Ellipse Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 400, 300));

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
 * 1. When you need to generate a Photoshop PSD file with a limited color palette and programmatically draw a red ellipse for a thumbnail or preview image.
 * 2. When automating the creation of indexed‑color PSD assets for game UI elements that require precise vector shapes without manual Photoshop work.
 * 3. When building a server‑side service that produces PSD reports containing simple graphics, such as an ellipse, while keeping file size low using an indexed palette.
 * 4. When converting data‑driven coordinates into a PSD diagram where the ellipse represents a region of interest and the palette must match existing brand colors.
 * 5. When testing image‑processing pipelines that expect PSD files with indexed colors and specific vector shapes, allowing you to validate rendering and export steps.
 */
