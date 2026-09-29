// HOW-TO: Convert Single Page CDR to High Quality JPG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cdr";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new JpegOptions
                {
                    Quality = 100
                };
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
 * 1. When a developer needs to generate a printable JPEG from a CorelDRAW single‑page design for web preview.
 * 2. When an application must batch‑convert CDR assets to JPEGs with maximum quality for a digital asset management system.
 * 3. When a reporting tool requires embedding a high‑resolution JPEG version of a CDR diagram into PDF reports.
 * 4. When a legacy workflow needs to transform a CDR file into a JPEG for email attachment without losing detail.
 * 5. When a mobile app backend must serve a JPEG thumbnail of a CDR illustration while preserving full color fidelity.
 */
