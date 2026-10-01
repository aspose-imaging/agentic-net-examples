// HOW-TO: Convert OTG to SVG While Preserving Layer Names in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to export an OTG design created in CorelDRAW to a scalable SVG for web display while keeping the original layer structure intact.
 * 2. When a CAD or illustration workflow requires converting multi‑layer OTG files to SVG so that downstream tools can manipulate each layer separately.
 * 3. When automating batch processing of OTG assets to SVG for a publishing pipeline, and you must retain layer names for indexing or styling purposes.
 * 4. When integrating Aspose.Imaging into a C# application to transform proprietary OTG graphics into SVG for responsive UI components without losing layer metadata.
 * 5. When migrating legacy OTG artwork to an SVG‑based asset library and need to preserve layer names for accurate search and categorization.
 */
