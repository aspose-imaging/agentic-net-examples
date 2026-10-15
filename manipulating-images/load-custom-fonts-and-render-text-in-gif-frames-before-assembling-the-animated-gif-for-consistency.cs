// HOW-TO: Load Custom Fonts and Render Text in Animated GIF with C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputGifPath = "input\\source.gif";
            string outputGifPath = "output\\animated.gif";
            string fontFolderPath = "fonts";

            if (!File.Exists(inputGifPath))
            {
                Console.Error.WriteLine($"File not found: {inputGifPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            LoadOptions loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fonts.ToArray();
            }, fontFolderPath);

            using (GifImage gif = (GifImage)Image.Load(inputGifPath, loadOptions))
            {
                string[] fontFiles = Directory.GetFiles(fontFolderPath);
                if (fontFiles.Length == 0)
                {
                    Console.Error.WriteLine("No font files found in the font folder.");
                    return;
                }
                string firstFontName = Path.GetFileNameWithoutExtension(fontFiles[0]);

                Font font = new Font(firstFontName, 24);
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    foreach (var page in gif.Pages)
                    {
                        gif.ActiveFrame = (GifFrameBlock)page;
                        Graphics graphics = new Graphics(gif.ActiveFrame);
                        graphics.DrawString("Sample Text", font, brush, new PointF(10, 10));
                    }
                }

                GifOptions gifOptions = new GifOptions();
                gif.Save(outputGifPath, gifOptions);
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
 * 1. When you need to add captions using a specific TrueType font to each frame of an existing GIF before creating an animated GIF.
 * 2. When you want to ensure text appearance is consistent across all frames by loading custom font files from a folder.
 * 3. When you are generating dynamic GIF banners where the text style must match corporate branding fonts not installed on the server.
 * 4. When you have to process a source GIF, overlay localized language strings with custom fonts, and output a new animated GIF.
 * 5. When you need to programmatically assemble an animated GIF from multiple frames while applying the same custom font to all text elements.
 */
