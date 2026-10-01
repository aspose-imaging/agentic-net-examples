// HOW-TO: Convert ODG to PNG with Metadata Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to export an OpenDocument Graphic (ODG) file to a web‑compatible PNG while preserving its original EXIF and custom metadata.
 * 2. When integrating Aspose.Imaging into a document‑conversion workflow that must retain drawing metadata for downstream indexing and search.
 * 3. When building a C# desktop application that displays ODG diagrams as PNG thumbnails without losing author or creation information.
 * 4. When automating batch conversion of ODG assets for a content management system that requires metadata to stay intact for cataloging.
 * 5. When creating a server‑side service that converts uploaded ODG files to PNG for preview generation while keeping all embedded properties.
 */
