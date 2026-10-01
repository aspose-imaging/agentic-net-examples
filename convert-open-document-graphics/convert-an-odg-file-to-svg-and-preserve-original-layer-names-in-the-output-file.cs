// HOW-TO: Convert ODG to SVG with Layer Names Using C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (SvgOptions options = new SvgOptions())
            {
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
 * 1. When you need to import an OpenDocument Graphics (ODG) illustration into a web page and keep its original layer structure as scalable SVG vectors.
 * 2. When a CAD or design workflow requires batch converting ODG files to SVG while retaining layer names for later editing in vector editors.
 * 3. When generating printable PDFs from ODG sources and you first convert them to SVG to preserve layer metadata for downstream processing.
 * 4. When building a C# application that automates migration of legacy ODG assets to modern SVG format without losing layer information.
 * 5. When integrating Aspose.Imaging into a document management system to display ODG diagrams as SVG graphics with intact layer naming for interactive UI features.
 */
