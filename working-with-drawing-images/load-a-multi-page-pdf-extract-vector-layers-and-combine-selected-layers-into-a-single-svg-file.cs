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
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions svgOptions = new SvgOptions();

                if (image is IMultipageImage multipage && multipage.PageCount > 2)
                {
                    svgOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));
                }

                VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to convert the first three pages of a multi‑page PDF into a single scalable SVG for responsive web display, they can use this Aspose.Imaging C# code.
 * 2. When an application must extract vector layers from a PDF and preserve them as editable SVG paths for a graphic‑design workflow, the snippet demonstrates how to rasterize with a white background and save the result.
 * 3. When generating print‑ready assets from a PDF brochure, a developer can select specific pages and output them as high‑quality SVG files using the MultiPageOptions and VectorRasterizationOptions shown.
 * 4. When building a document‑to‑vector conversion service that needs to programmatically combine selected PDF pages into one SVG for downstream processing, this code provides the necessary file‑format handling in .NET.
 * 5. When creating an automated pipeline that extracts vector graphics from legal or engineering PDFs and stores them as SVG for archival or further analysis, the example illustrates the required steps with Aspose.Imaging for .NET.
 */