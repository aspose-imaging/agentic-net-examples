// HOW-TO: Convert PDF Map to SVG with Vector Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "map.pdf");
            string outputPath = Path.Combine("Output", "map.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to use Aspose.Imaging in C# to embed high‑resolution vector maps from a PDF into a web page as scalable SVG graphics while preserving the original dimensions.
 * 2. When a GIS application requires converting PDF map reports into SVG files with Aspose.Imaging for further styling with CSS or JavaScript.
 * 3. When an automated C# pipeline must transform PDF‑based cartographic assets into SVG format using Aspose.Imaging without losing coordinate accuracy.
 * 4. When you want to generate SVG assets from PDF maps for mobile apps that need resolution‑independent graphics and retain geographic metadata via Aspose.Imaging.
 * 5. When a document management system needs to store map PDFs as searchable SVG files using Aspose.Imaging to improve rendering speed and accessibility.
 */
