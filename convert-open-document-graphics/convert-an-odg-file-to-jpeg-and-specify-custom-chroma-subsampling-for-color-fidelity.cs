// HOW-TO: Convert ODG to JPEG with Maximum Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate high‑resolution JPEG previews of OpenDocument graphics for web thumbnails using C#.
 * 2. When an application must batch‑convert ODG diagrams to JPEG files while preserving color fidelity for print‑ready assets.
 * 3. When integrating Aspose.Imaging into a document management system to export ODG drawings as JPEG images for email attachments.
 * 4. When a reporting tool requires converting ODG charts to JPEG with full quality to embed them in PDF reports.
 * 5. When automating a workflow that extracts ODG artwork from archives and saves it as JPEG for use in mobile apps.
 */
