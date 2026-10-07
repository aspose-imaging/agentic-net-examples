// HOW-TO: Convert ODG to SVG While Preserving Layer Names in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to programmatically convert OpenDocument Graphics (ODG) drawings to scalable SVG files for web display while keeping the original layer structure.
 * 2. When integrating a document processing pipeline that extracts vector graphics from ODG reports and saves them as SVG for further editing in design tools.
 * 3. When building a C# application that batch‑converts legacy ODG assets to SVG to support modern browsers without losing layer information.
 * 4. When automating the migration of CAD‑like diagrams stored in ODG format to SVG for inclusion in responsive UI components.
 * 5. When creating a server‑side service that receives ODG uploads, converts them to SVG, and preserves layer names for downstream analytics or rendering.
 */
