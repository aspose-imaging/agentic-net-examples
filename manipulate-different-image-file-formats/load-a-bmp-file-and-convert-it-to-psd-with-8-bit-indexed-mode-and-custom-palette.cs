// HOW-TO: Convert BMP to 8‑Bit Indexed PSD with Custom Grayscale Palette in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "source.bmp");
            string outputPath = Path.Combine("Output", "result.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PsdOptions options = new PsdOptions();
                options.Source = new FileCreateSource(outputPath, false);
                options.ColorMode = ColorModes.Indexed;

                Color[] paletteColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    paletteColors[i] = Color.FromArgb(i, i, i);
                }
                options.Palette = new ColorPalette(paletteColors);

                using (Image psd = Image.Create(options, image.Width, image.Height))
                {
                    Graphics graphics = new Graphics(psd);
                    graphics.DrawImage(image, 0, 0);
                    psd.Save();
                }
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
 * 1. When you need to import legacy BMP assets into Photoshop while preserving a limited 256‑color palette for web‑optimized graphics.
 * 2. When generating PSD files for a design pipeline that requires 8‑bit indexed mode to reduce file size without losing specific grayscale tones.
 * 3. When converting scanned bitmap images to PSD format to allow layer‑based editing in Photoshop while maintaining a custom color map.
 * 4. When building an automated batch process that transforms BMP icons into indexed PSDs for use in UI mockups with a predefined palette.
 * 5. When creating PSD previews of BMP textures for game development, ensuring the output uses an 8‑bit indexed color mode with a controlled palette.
 */
