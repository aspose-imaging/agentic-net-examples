// HOW-TO: Convert PDF Vector Diagram to SVG While Preserving Line Widths in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Input\diagram.pdf";
            string outputPath = @"C:\Output\diagram.svg";

            // Verify that the input PDF exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF (vector image) using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to keep the original page size,
                // which preserves line widths and scaling.
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Do not compress to keep the SVG fully vectorial
                    Compress = false
                };

                // Save the PDF as SVG
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
 * 1. When a developer needs to embed engineering schematics from a PDF into a responsive web page without losing the original line thickness.
 * 2. When an application must transform architectural drawing PDFs into scalable SVG files for zoom‑able documentation viewers.
 * 3. When preserving exact line widths is critical for generating printable vector graphics from PDF technical manuals.
 * 4. When converting CAD‑exported PDF diagrams to SVG for use in interactive dashboards that require precise scaling.
 * 5. When automating the migration of legacy PDF vector assets to SVG to support modern UI frameworks while keeping visual fidelity.
 */
