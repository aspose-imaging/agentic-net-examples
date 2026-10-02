// HOW-TO: Convert BMP to JPEG with Adjustable Quality Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output/output.jpg";
                int quality = 90;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = quality
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
 * 1. When a developer needs to reduce the file size of high‑resolution BMP screenshots for web upload by saving them as JPEG with a specific quality setting.
 * 2. When integrating a .NET application that receives BMP images from legacy hardware and must store them as compressed JPEGs for archival storage.
 * 3. When building an automated pipeline that converts user‑uploaded BMP avatars to JPEG thumbnails while preserving visual fidelity through configurable compression.
 * 4. When migrating a document management system from BMP‑based assets to JPEG to improve loading speed, and the conversion quality must be tuned per project requirements.
 * 5. When creating a desktop utility that allows end‑users to select a BMP file and export it as a JPEG with a chosen quality level for printing or sharing.
 */
