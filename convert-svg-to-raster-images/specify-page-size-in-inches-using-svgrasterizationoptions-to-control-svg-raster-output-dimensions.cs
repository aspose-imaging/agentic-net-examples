// HOW-TO: Convert SVG to PNG with Specific Inch Dimensions and DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double widthInches = 4.0;
            double heightInches = 3.0;
            int dpi = 300;
            int pageWidth = (int)(widthInches * dpi);
            int pageHeight = (int)(heightInches * dpi);

            using (var pngOptions = new PngOptions())
            {
                pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = pageWidth,
                    PageHeight = pageHeight
                };
                pngOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(dpi, dpi);

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a high‑resolution PNG thumbnail of an SVG logo that fits exactly a 4 × 3‑inch print area at 300 dpi.
 * 2. When creating printable product labels from vector SVG templates and must ensure the raster image matches the required physical size.
 * 3. When exporting SVG diagrams to PNG for inclusion in a PDF report where the image must occupy a precise inch‑based layout.
 * 4. When automating batch conversion of SVG assets for a web‑to‑print workflow that demands consistent page dimensions across all output files.
 * 5. When developing a C# application that renders SVG icons at a fixed size for UI elements on high‑density displays.
 */
