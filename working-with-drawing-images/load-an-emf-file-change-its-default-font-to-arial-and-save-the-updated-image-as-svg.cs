using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            string arialFontFolder = @"C:\Windows\Fonts";
            loadOptions.AddCustomFontSource(
                (object[] fontArgs) =>
                {
                    string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
                    var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath, "*.ttf"))
                        {
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                    return result.ToArray();
                },
                arialFontFolder);

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath, loadOptions))
            {
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                emfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) diagrams into scalable web‑friendly SVG files while ensuring all text appears in a consistent Arial font for brand compliance.
 * 2. When an automated reporting system must replace missing or unsupported fonts in EMF charts with Arial before exporting them as SVG to embed in HTML dashboards.
 * 3. When a document‑generation pipeline processes user‑uploaded EMF logos and standardizes the typography to Arial before saving them as SVG for responsive UI rendering.
 * 4. When a batch conversion tool has to load multiple EMF assets, inject a custom Arial font from the system fonts folder, and output SVG files that preserve text as shapes for cross‑platform compatibility.
 * 5. When a GIS application imports EMF map overlays, forces the default font to Arial to match corporate style guidelines, and exports the result as SVG for high‑resolution printing.
 */