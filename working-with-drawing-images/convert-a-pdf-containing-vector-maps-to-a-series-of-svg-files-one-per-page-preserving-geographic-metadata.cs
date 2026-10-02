// HOW-TO: Convert PDF Map Pages to Separate SVG Files with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\map.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputBaseDir = "Output";
            Directory.CreateDirectory(outputBaseDir);

            using (Image pdfImage = Image.Load(inputPath))
            {
                if (pdfImage is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        string outputPath = Path.Combine(outputBaseDir, $"page_{i + 1}.svg");
                        string outDir = Path.GetDirectoryName(outputPath);
                        Directory.CreateDirectory(outDir);

                        var svgOptions = new SvgOptions
                        {
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                        };

                        pdfImage.Save(outputPath, svgOptions);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputBaseDir, "page_1.svg");
                    string outDir = Path.GetDirectoryName(outputPath);
                    Directory.CreateDirectory(outDir);

                    var svgOptions = new SvgOptions();
                    pdfImage.Save(outputPath, svgOptions);
                }
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
 * 1. When you need to extract each page of a PDF containing vector maps into individual SVG files for web‑based GIS visualisation.
 * 2. When a GIS application requires the geographic metadata from a PDF map to be retained while converting pages to scalable SVG graphics.
 * 3. When automating a batch process that turns multi‑page PDF atlases into separate SVG layers for further editing in vector design tools.
 * 4. When a server‑side C# service must deliver per‑page SVG representations of a PDF map to client browsers without losing vector quality.
 * 5. When integrating Aspose.Imaging into a .NET workflow to split a single PDF map document into multiple SVG assets for responsive mobile mapping apps.
 */
