// HOW-TO: Convert EMF to Transparent PNG with 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                VectorImage vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
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
 * 1. When you need to embed a vector graphic from an EMF file into a web page without a background and at print‑ready 300 DPI resolution.
 * 2. When generating high‑resolution PNG assets from legacy Windows Metafile diagrams for inclusion in PDF reports.
 * 3. When creating transparent icons from EMF logos for use in mobile or desktop applications that require 300 DPI raster images.
 * 4. When preprocessing EMF drawings for a printing workflow that demands a background‑free PNG at a specific DPI.
 * 5. When automating batch conversion of EMF files to PNG with transparent backgrounds for a digital asset management system.
 */
