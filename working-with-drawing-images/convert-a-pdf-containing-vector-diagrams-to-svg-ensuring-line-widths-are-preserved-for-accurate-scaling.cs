using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.pdf";
        string outputPath = "output/output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to preserve line widths
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                };

                // Set up SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as SVG
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
 * 1. When a developer needs to embed engineering schematics from a PDF into a responsive web page and must keep the original line widths intact for accurate scaling, they can use this C# Aspose.Imaging code to convert the PDF to SVG.
 * 2. When a CAD application exports design drawings as PDF and the downstream workflow requires vector SVG files for further editing in Illustrator while preserving line thickness, the provided code handles the conversion.
 * 3. When an e‑learning platform wants to display printable vector diagrams from PDF textbooks on high‑DPI screens without distortion, the code converts the PDF to SVG with line‑width preservation using Aspose.Imaging.
 * 4. When a mobile app must download PDF technical manuals and render them as scalable SVG assets to reduce memory usage, developers can apply this C# snippet to rasterize the PDF pages while maintaining exact line widths.
 * 5. When a document management system automates batch processing of PDF reports containing charts and needs SVG output for SEO‑friendly web publishing, this code ensures the vector graphics retain their original line widths during conversion.
 */