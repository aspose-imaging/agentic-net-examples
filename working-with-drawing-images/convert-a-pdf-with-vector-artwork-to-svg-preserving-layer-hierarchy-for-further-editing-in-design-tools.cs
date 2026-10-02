// HOW-TO: Convert PDF With Vector Layers To SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace PdfToSvgConverter
{
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

                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

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
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to export a multi‑layer PDF brochure into an editable SVG for further refinement in Illustrator or Inkscape.
 * 2. When an automated build process must transform PDF schematics into scalable SVG graphics for web display without losing vector quality.
 * 3. When a reporting tool generates PDF charts and the application must convert them to SVG to enable interactive zoom and styling in a web dashboard.
 * 4. When a migration script has to preserve the original PDF layer hierarchy while converting architectural drawings to SVG for CAD integration.
 * 5. When a content management system stores PDFs and requires on‑the‑fly conversion to SVG to support responsive design and client‑side editing.
 */
