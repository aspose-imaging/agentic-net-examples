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
            string inputPath = @"C:\temp\input.pdf";
            string outputPath = @"C:\temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pdfImage = Image.Load(inputPath))
            {
                SvgOptions exportOptions = new SvgOptions();

                exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));

                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = pdfImage.Width,
                    PageHeight = pdfImage.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                exportOptions.VectorRasterizationOptions = rasterOptions;

                pdfImage.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to convert specific pages of a multi‑page PDF into a single scalable SVG for web display, they can use this code to extract the vector layers and combine them.
 * 2. When generating printable vector graphics from a PDF invoice that spans multiple pages, the snippet lets you rasterize selected pages into one SVG file while preserving text rendering hints.
 * 3. When building a document‑to‑diagram conversion tool that requires merging vector content from several PDF pages into an interactive SVG diagram, this example shows how to load, select, and export the layers.
 * 4. When creating an automated workflow that extracts vector artwork from architectural PDF drawings and consolidates chosen pages into a single SVG for CAD integration, the code provides the necessary Aspose.Imaging steps.
 * 5. When developing a batch process that converts a range of PDF pages into a lightweight SVG for mobile apps, this sample demonstrates how to set MultiPageOptions and VectorRasterizationOptions in C#.
 */