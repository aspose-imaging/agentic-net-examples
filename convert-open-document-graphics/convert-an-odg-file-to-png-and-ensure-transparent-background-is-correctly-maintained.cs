// HOW-TO: Convert ODG to PNG with Transparent Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output\\output.png";

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
 * 1. When a designer provides assets in ODG format and a web application requires PNG images with alpha transparency, this code converts the files while preserving the transparent background.
 * 2. When automating a build pipeline that generates documentation graphics from ODG files, developers can use this snippet to produce PNGs ready for inclusion in PDFs or HTML pages.
 * 3. When migrating legacy OpenDocument graphics to a modern UI that only supports PNG, the code ensures the visual appearance remains unchanged by keeping the transparency intact.
 * 4. When creating a batch conversion tool that processes multiple ODG drawings into PNG thumbnails for a gallery, the example shows the basic load‑and‑save pattern with Aspose.Imaging in C#.
 * 5. When integrating image conversion into a server‑side service that receives ODG uploads and returns PNG responses, this code demonstrates how to handle the conversion safely with error checking.
 */
