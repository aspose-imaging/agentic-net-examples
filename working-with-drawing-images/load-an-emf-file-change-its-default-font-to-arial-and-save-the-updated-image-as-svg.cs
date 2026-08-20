// HOW-TO: Convert EMF to SVG with Arial Font Replacement in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\temp\\input.emf";
            string outputPath = "C:\\temp\\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new Aspose.Imaging.LoadOptions();
            loadOptions.AddCustomFontSource((object[] fontArgs) =>
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
            });

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                var emfImage = (Aspose.Imaging.FileFormats.Emf.EmfImage)image;

                var saveOptions = new Aspose.Imaging.ImageOptions.SvgOptions
                {
                    TextAsShapes = false
                };

                var rasterOptions = new Aspose.Imaging.ImageOptions.EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
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
 * 1. When a Windows application needs to display legacy EMF diagrams on the web, a developer can convert the EMF files to scalable SVG format and replace missing fonts with Arial to ensure consistent rendering.
 * 2. When generating printable reports that include vector graphics, a developer may convert EMF charts to SVG and enforce a standard font so the output looks the same on systems without the original fonts installed.
 * 3. When migrating a design asset library from Windows Metafile to a cross‑platform format, a developer can use this code to batch‑convert EMF files to SVG while normalizing all text to Arial for uniform appearance.
 * 4. When creating an automated build pipeline that processes user‑uploaded EMF logos, a developer can convert them to SVG and embed Arial as the default font to avoid font‑fallback issues in browsers.
 * 5. When integrating legacy engineering drawings into a modern C# web portal, a developer can transform the EMF drawings into SVG and substitute the original fonts with Arial to guarantee that the drawings render correctly on all devices.
 */
