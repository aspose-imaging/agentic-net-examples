using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
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
 * 1. When a developer needs to convert an SVG logo into a 300 dpi PNG for print‑ready marketing materials.
 * 2. When an e‑commerce platform must generate high‑resolution product thumbnails from vector artwork on the fly using C# and Aspose.Imaging.
 * 3. When a reporting tool requires embedding scalable diagrams as raster images in PDF reports, ensuring consistent resolution across devices.
 * 4. When a desktop application automates the creation of UI mockups by rendering SVG icons to PNG assets for Windows forms.
 * 5. When a batch processing script validates the existence of source SVG files and produces lossless PNG files with specified DPI for archival purposes.
 */