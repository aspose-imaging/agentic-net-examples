using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.pdf";
            string outputPath = "Output\\sample.svg";

            // Validate input file existence
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
                // Configure SVG save options
                using (SvgOptions saveOptions = new SvgOptions())
                {
                    // Preserve text as selectable (do not convert to shapes)
                    saveOptions.TextAsShapes = false;

                    // Set vector rasterization options (optional, e.g., background color)
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };
                    saveOptions.VectorRasterizationOptions = vectorOptions;

                    // Save as SVG
                    image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to embed a high‑resolution PDF diagram into a responsive web page and wants the text to remain searchable and selectable, they can use this code to convert the PDF to SVG while preserving text elements.
 * 2. When an e‑learning platform must display printable vector illustrations from PDF lesson materials in browsers without losing accessibility, the conversion to SVG with selectable text enables screen readers to read the content.
 * 3. When a SaaS application generates dynamic reports in PDF and wants to provide an interactive preview that scales on any device, converting the PDF to SVG keeps the vector graphics crisp and the text editable for copy‑paste.
 * 4. When a marketing team requires SEO‑friendly graphics extracted from product brochures in PDF format, this code creates SVG files where the text remains indexable by search engines.
 * 5. When a developer is building a document‑to‑web conversion pipeline that must retain exact layout and allow users to copy text from technical schematics, the Aspose.Imaging PDF‑to‑SVG conversion with TextAsShapes set to false fulfills that need.
 */