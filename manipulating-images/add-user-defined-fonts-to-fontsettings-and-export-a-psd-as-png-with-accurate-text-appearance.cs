// HOW-TO: Export PSD to PNG with Custom Fonts Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";
            string fontsFolder = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FontSettings.SetFontsFolder(fontsFolder);
            FontSettings.UpdateFonts();

            using (Image image = Image.Load(inputPath))
            {
                var vectorOpts = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOpts
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a web service needs to generate thumbnail PNGs from PSD designs that use brand‑specific fonts stored in a custom folder.
 * 2. When an automated build pipeline converts layered Photoshop files to PNG for documentation while preserving exact text appearance with user‑defined fonts.
 * 3. When a desktop application batch‑processes PSD assets and must embed non‑system fonts to ensure consistent rendering across different machines.
 * 4. When a SaaS platform offers on‑the‑fly image previews of user‑uploaded PSD files and must load fonts from a dedicated directory to avoid missing‑glyph errors.
 * 5. When a migration script extracts vector text from PSDs and rasterizes it to PNG with precise rendering settings such as single‑bit per pixel and no smoothing.
 */
