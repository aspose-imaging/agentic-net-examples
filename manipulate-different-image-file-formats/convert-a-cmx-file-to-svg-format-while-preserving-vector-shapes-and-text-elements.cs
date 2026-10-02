// HOW-TO: Convert CMX Vector File to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cmx";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to migrate legacy CorelDRAW CMX artwork to web‑ready SVG graphics without losing vector paths or editable text.
 * 2. When an automated build process must batch‑convert CMX design files to scalable SVGs for responsive UI assets.
 * 3. When a document management system stores CMX files and you want to generate SVG previews for fast browser rendering.
 * 4. When integrating a C# application that imports CMX drawings and exports them as SVG for further processing in vector editors.
 * 5. When creating a conversion tool that preserves original text elements while turning CMX files into SVG for printing workflows.
 */
