// HOW-TO: Extract Selected PDF Pages As Vector SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pdf";
        string outputPath = "output/output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions exportOptions = new SvgOptions
                {
                    MultiPageOptions = new MultiPageOptions(new IntRange(0, 2)),
                    TextAsShapes = true,
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
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
 * 1. When you need to convert specific pages of a multi‑page PDF into a scalable SVG for web display without losing vector quality.
 * 2. When you want to combine vector graphics from several PDF pages into a single SVG file for inclusion in a design system.
 * 3. When you must preserve text as editable shapes during PDF‑to‑SVG conversion to enable further editing in vector editors.
 * 4. When you are building a C# service that extracts vector layers from PDFs and stores them as white‑background SVGs for printing workflows.
 * 5. When you require automated batch processing of PDFs to generate SVG assets for responsive UI components in a .NET application.
 */
