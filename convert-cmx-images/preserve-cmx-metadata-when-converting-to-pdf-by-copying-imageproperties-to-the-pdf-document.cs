// HOW-TO: Convert CMX to PDF While Preserving Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                CmxImage cmx = (CmxImage)image;
                var options = new PdfOptions();
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
 * 1. When you need to generate PDF reports from legacy CorelDRAW CMX files without losing original author or creation information.
 * 2. When an automated document pipeline must batch‑convert CMX artwork to PDF while keeping embedded XMP or custom metadata for downstream indexing.
 * 3. When a web service receives CMX uploads and must return PDF previews that retain the source file’s properties for audit compliance.
 * 4. When integrating Aspose.Imaging into a C# application to migrate archived CMX assets to PDF while preserving image resolution and color profile metadata.
 * 5. When creating a migration tool that moves design assets from CMX to PDF and requires the original metadata to be searchable in a content management system.
 */
