using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.psd";
            string outputPath = "output/output.png";
            string fontsFolder = "Fonts";

            // Input file validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PSD image with custom fonts
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(args =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return result.ToArray();
            }, fontsFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare PNG options with vector rasterization to preserve text appearance
                var pngOptions = new PngOptions();
                var vectorOpts = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pngOptions.VectorRasterizationOptions = vectorOpts;

                // Save as PNG
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
 * 1. When a web‑based design preview tool needs to convert client‑uploaded Photoshop PSD files to PNG thumbnails while preserving the exact look of custom‑font text layers, developers can use this code.
 * 2. When an automated marketing pipeline must generate high‑resolution product images from PSD templates that use brand‑specific fonts stored in a separate folder, the code ensures the fonts are loaded and the PNG output matches the original design.
 * 3. When a desktop application that batch‑processes PSD assets for e‑learning content has to replace missing system fonts with user‑provided font files and export the pages as PNG for LMS compatibility, this approach handles the font substitution and rasterization.
 * 4. When a CI/CD build step creates visual regression screenshots by rendering PSD mockups with embedded corporate fonts into PNG files for comparison in test reports, the code guarantees consistent text rendering across build agents.
 * 5. When a cloud service that offers on‑the‑fly image conversion needs to support PSD files containing non‑standard fonts and deliver PNG responses to API callers, developers can employ this snippet to load custom fonts and preserve text appearance.
 */