using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos as high‑resolution PNG files for display across different browsers using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform must convert product vector illustrations (SVG) into PNG images to embed in email newsletters that only support raster formats.
 * 3. When a desktop publishing tool automates the creation of print‑ready PNG assets from SVG artwork while preserving color fidelity with Image.Load and PngOptions.
 * 4. When a mobile app backend processes SVG icons and saves them as PNG spritesheets to reduce client‑side rendering overhead.
 * 5. When a reporting service transforms SVG charts into high‑resolution PNG images for inclusion in PDF reports generated with .NET.
 */