using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.pdf";
            string outputPath = "output/output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF and export first two pages to SVG
            using (Image image = Image.Load(inputPath))
            {
                SvgOptions exportOptions = new SvgOptions
                {
                    MultiPageOptions = new MultiPageOptions(new IntRange(0, 2))
                };

                image.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to convert the first two pages of a multi‑page PDF brochure into a scalable SVG for responsive web display, they can use this code.
 * 2. When an engineering team wants to extract vector layers from a PDF technical drawing and merge them into a single SVG for inclusion in CAD documentation, this snippet provides the solution.
 * 3. When a publishing workflow requires batch conversion of selected PDF pages into SVG assets for high‑resolution printing, the code demonstrates how to achieve it with Aspose.Imaging for .NET.
 * 4. When a SaaS platform must generate lightweight, searchable vector graphics from user‑uploaded PDF reports, developers can apply this example to export specific pages as SVG.
 * 5. When an e‑learning application needs to embed vector‑based illustrations from a multi‑page PDF curriculum into HTML5 lessons, this code shows how to extract and combine the needed pages into one SVG file.
 */