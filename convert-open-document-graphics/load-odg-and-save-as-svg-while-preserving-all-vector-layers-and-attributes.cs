// HOW-TO: Convert ODG to SVG with Vector Layers Preserved in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to embed an OpenDocument graphics file into a web page that only supports SVG, you can convert the ODG to SVG while keeping all vector information.
 * 2. When a design workflow requires exchanging vector artwork between LibreOffice Draw and a browser‑based editor, this code preserves layers and attributes during the conversion.
 * 3. When automating batch processing of ODG assets for a digital publishing pipeline, you can programmatically load each ODG and save it as an SVG for scalable rendering.
 * 4. When creating a C# service that generates printable diagrams from ODG templates, converting to SVG ensures resolution‑independent output for PDF generation.
 * 5. When integrating legacy ODG diagrams into a modern .NET application that uses SVG for charting or annotation, this snippet maintains the original vector structure.
 */
