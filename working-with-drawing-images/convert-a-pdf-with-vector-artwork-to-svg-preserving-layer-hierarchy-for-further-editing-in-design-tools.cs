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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Input\sample.pdf";
            string outputPath = @"C:\Output\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    // Render text as shapes to keep editability
                    TextAsShapes = true,
                    // Set page size based on the source image
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // If the PDF has multiple pages, export only the first page
                if (image is IMultipageImage multipage && multipage.PageCount > 1)
                {
                    svgOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 1));
                }

                // Save as SVG, preserving vector layers
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
 * 1. When a developer needs to convert a multi‑page PDF containing vector graphics into an editable SVG file while preserving the original layer hierarchy for use in design tools like Adobe Illustrator.
 * 2. When an automated workflow must extract the first page of a PDF brochure and generate an SVG where all text is rendered as shapes to keep the typography editable in downstream editing.
 * 3. When a C# application has to batch‑process PDF assets from a file system, ensuring the output SVG matches the source page size and retains vector fidelity for responsive web graphics.
 * 4. When a .NET service integrates Aspose.Imaging to transform client‑uploaded PDFs into scalable SVGs that can be further manipulated via CSS or JavaScript without rasterizing the artwork.
 * 5. When a developer wants to validate the existence of input PDF files, create the necessary output directories, and safely export vector layers to SVG using SvgOptions and MultiPageOptions in a try‑catch block.
 */