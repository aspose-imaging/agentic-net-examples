// HOW-TO: Convert PDF Vector Diagrams to SVG with Line Width Preservation in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.pdf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to export engineering schematics stored in a PDF to scalable SVG files for web display while keeping exact line thickness.
 * 2. When a CAD application must generate SVG assets from PDF drawings so that the graphics scale correctly on different screen resolutions.
 * 3. When an automated reporting tool converts PDF charts into SVG vectors to embed in responsive HTML dashboards without losing line weight fidelity.
 * 4. When a documentation pipeline transforms PDF user‑manual illustrations into SVG icons for inclusion in mobile apps that require precise scaling.
 * 5. When a batch process migrates a library of PDF vector artwork to SVG format for use in vector‑based editors while preserving line widths.
 */
