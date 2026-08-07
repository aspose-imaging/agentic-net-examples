using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var emfImage = (Aspose.Imaging.FileFormats.Emf.EmfImage)image;

                // Remove background (default settings)
                emfImage.RemoveBackground(new RemoveBackgroundSettings());

                // Configure PNG export with 300 DPI resolution
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Aspose.Imaging.Color.Transparent
                    }
                };

                emfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) diagrams into high‑resolution PNG images for web publishing while stripping the original white background.
 * 2. When an application must generate print‑ready PNG assets from vector EMF logos, ensuring a 300 DPI resolution and transparent background for overlay on marketing materials.
 * 3. When a reporting tool has to embed EMF charts into PDF reports by first rasterizing them to PNG at 300 DPI and removing the background to match the document’s theme.
 * 4. When a batch‑processing service automates the migration of EMF icons to PNG thumbnails with consistent DPI and no background clutter for use in mobile apps.
 * 5. When a GIS system requires converting EMF map overlays into PNG layers at 300 DPI, eliminating the background so the layers can be stacked transparently in a mapping UI.
 */