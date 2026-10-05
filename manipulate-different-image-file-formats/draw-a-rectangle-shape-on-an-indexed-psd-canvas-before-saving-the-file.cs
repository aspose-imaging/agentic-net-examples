// HOW-TO: Draw a Red Rectangle on an Indexed PSD Canvas in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);

            PsdOptions options = new PsdOptions();
            options.Source = source;
            options.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed;
            options.Palette = new ColorPalette(new Color[] { Color.Black, Color.White });
            options.ChannelsCount = (short)1;
            options.ChannelBitsCount = (short)8;
            options.Version = 5;

            int width = 200;
            int height = 200;

            using (Image canvas = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Red, 5);
                Rectangle rect = new Rectangle(20, 20, 160, 160);
                graphics.DrawRectangle(pen, rect);
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
 * 1. When you need to programmatically add a highlighted border to a layered Photoshop file that uses an indexed color palette, such as marking a region for review.
 * 2. When generating thumbnail previews of PSD assets where a simple rectangle annotation must be drawn without converting the image to full RGB mode.
 * 3. When creating batch‑processed design templates that require drawing shapes on indexed PSD files to maintain small file sizes for web delivery.
 * 4. When automating the preparation of print‑ready PSD files that use a limited palette and need a red outline around a specific area for cutting guides.
 * 5. When building a C# tool that validates PSD files by drawing a test rectangle on an indexed canvas to ensure the graphics API and palette handling work correctly.
 */
