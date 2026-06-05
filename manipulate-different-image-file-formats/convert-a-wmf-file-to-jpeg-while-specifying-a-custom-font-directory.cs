using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output/output.jpg";
        string fontFolder = "fonts";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((argsArray) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (argsArray.Length > 0)
                {
                    string fontsPath = argsArray[0]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            byte[] fontData = File.ReadAllBytes(fontFile);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                        }
                    }
                }
                return fonts.ToArray();
            }, fontFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a Windows desktop application must generate preview thumbnails of legacy WMF vector drawings as JPEG images while using a private collection of corporate fonts stored in a custom folder.
 * 2. When an automated document conversion service needs to render WMF diagrams that reference non‑system fonts into high‑quality JPEG files for web display.
 * 3. When a batch processing script converts a large archive of WMF files to JPEG format on a build server that does not have the required fonts installed globally.
 * 4. When a reporting tool embeds WMF charts into PDF reports and first converts them to JPEG using a specific font directory to ensure consistent text appearance across platforms.
 * 5. When a migration utility moves legacy engineering schematics from WMF to JPEG for archival, while loading custom TrueType fonts from a designated folder to preserve label styling.
 */