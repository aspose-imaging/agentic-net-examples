// HOW-TO: Extract PDF Vector Map Pages to Individual SVG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputDir = "output_svgs";

            Directory.CreateDirectory(outputDir);

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image pdfImage = Image.Load(inputPath))
            {
                if (pdfImage is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var rasterOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };

                        var exportOptions = new SvgOptions
                        {
                            VectorRasterizationOptions = rasterOptions,
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                        };

                        pdfImage.Save(outputPath, exportOptions);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    var exportOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    pdfImage.Save(outputPath, exportOptions);
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
 * 1. When a GIS application needs each page of a multi‑page PDF map as a separate SVG for web display.
 * 2. When a developer wants to preserve geographic metadata while converting vector maps from PDF to scalable SVG for interactive dashboards.
 * 3. When an automated pipeline must split a PDF atlas into per‑page SVG assets for responsive mobile mapping.
 * 4. When a mapping service requires white‑background SVGs with exact rasterization settings to maintain visual fidelity across browsers.
 * 5. When a data‑visualization tool needs to programmatically export PDF map layers to SVG files for further styling with CSS.
 */
