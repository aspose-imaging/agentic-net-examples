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
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to generate a searchable PDF report that consolidates dozens of legacy WMF diagrams into a single document with a clickable table of contents for easy navigation.
 * 2. When an engineering team wants to archive vector‑based schematics stored as WMF files into a PDF portfolio that preserves quality and provides a hyperlinked index of each schematic name.
 * 3. When a software solution must export WMF icons and flowcharts from a Windows application into a printable PDF handbook, automatically creating a TOC that links to each icon’s title.
 * 4. When a legal compliance system requires converting a batch of WMF signatures into a single PDF evidence file, with a table of contents that references each signer’s file name for quick review.
 * 5. When a content management workflow automates the transformation of WMF marketing assets into a PDF catalog, adding a navigable TOC so marketers can jump directly to the asset named in the catalog.
 */