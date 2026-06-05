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
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
            string fontDir = "Fonts";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            if (!Directory.Exists(fontDir))
            {
                Directory.CreateDirectory(fontDir);
            }

            var files = Directory.GetFiles(inputDir, "*.wmf");
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource((args) =>
                {
                    var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (args.Length > 0)
                    {
                        string fontsPath = args[0]?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                        {
                            foreach (var fontFile in Directory.GetFiles(fontsPath))
                            {
                                byte[] fontBytes = File.ReadAllBytes(fontFile);
                                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                                result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                            }
                        }
                    }
                    return result.ToArray();
                }, fontDir);

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    var jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

                    image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert a large collection of legacy Windows Metafile (WMF) diagrams into web‑friendly JPEG images while ensuring that custom corporate fonts are applied during rendering.
 * 2. When an automated build pipeline must generate thumbnail previews of WMF icons stored in a source folder and output them as JPEG files for inclusion in documentation portals.
 * 3. When a migration tool has to replace outdated WMF assets with high‑resolution JPEGs in a content management system, using a specific font directory to preserve brand typography.
 * 4. When a desktop application processes user‑uploaded WMF drawings in bulk, applying a custom font set from a network share before saving the results as JPEG for further editing.
 * 5. When a reporting service needs to batch render WMF charts with organization‑specific fonts into JPEG format for email distribution or PDF embedding.
 */