// HOW-TO: Convert CorelDRAW CDR to JPEG with Quality 90 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CdrToJpgConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑ready preview images from CorelDRAW files while preserving visual fidelity by setting JPEG quality to 90.
 * 2. When an automated build pipeline must batch‑convert CDR assets to JPEG for inclusion in a mobile app with consistent compression settings.
 * 3. When a digital asset management system imports user‑uploaded CDR designs and stores them as high‑quality JPEG thumbnails for quick browsing.
 * 4. When a reporting tool creates printable PDFs that embed JPEG versions of CDR diagrams, requiring a specific quality level to balance size and clarity.
 * 5. When a cloud service processes design files on‑the‑fly, converting CDR to JPEG with a predefined quality to meet client‑specified image standards.
 */
