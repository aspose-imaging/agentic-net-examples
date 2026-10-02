// HOW-TO: Convert WMF to SVG Preserving Fonts and Text Layout in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = false
                };

                wmfImage.Save(outputPath, svgOptions);
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
 * 1. When you need to display legacy Windows Metafile graphics on modern web pages that require scalable SVG without losing the original font styling.
 * 2. When converting batch WMF assets from a desktop publishing workflow to SVG for responsive UI designs while keeping text editable.
 * 3. When migrating a CAD or diagram library from WMF to SVG to enable zoom‑in without rasterization artifacts and retain accurate text positioning.
 * 4. When automating the generation of printable SVG files from WMF reports so that embedded fonts are preserved for high‑quality PDF conversion.
 * 5. When integrating a document conversion service that transforms WMF icons into SVG icons for use in cross‑platform mobile apps while maintaining text layout.
 */
