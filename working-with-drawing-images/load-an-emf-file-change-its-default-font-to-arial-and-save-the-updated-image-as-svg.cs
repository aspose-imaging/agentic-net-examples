using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare custom font source to ensure Arial is available
            var loadOptions = new LoadOptions();
            string fontsFolder = @"C:\Windows\Fonts";

            loadOptions.AddCustomFontSource((object[] fontArgs) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (Directory.Exists(fontsFolder))
                {
                    foreach (var file in Directory.GetFiles(fontsFolder, "*.ttf"))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fonts.ToArray();
            }, fontsFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var emfImage = (Aspose.Imaging.FileFormats.Emf.EmfImage)image;

                var saveOptions = new SvgOptions
                {
                    TextAsShapes = false
                };

                var rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
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
 * 1. When a Windows desktop application needs to convert legacy EMF vector graphics to web‑friendly SVG while ensuring all text appears in the Arial font for consistent branding.
 * 2. When a reporting tool generates charts as EMF files and must embed them in HTML emails, requiring raster‑free SVG output with a standardized font.
 * 3. When a document management system imports EMF drawings from CAD software and must re‑export them as scalable SVG files that use Arial to match corporate style guidelines.
 * 4. When a batch processing script updates a large collection of EMF icons, replacing missing or varied fonts with Arial before converting them to SVG for use in responsive UI designs.
 * 5. When a migration project moves legacy Windows forms graphics to a cross‑platform .NET Core web app, needing to load EMF, set the default font to Arial, and save as SVG for modern browsers.
 */