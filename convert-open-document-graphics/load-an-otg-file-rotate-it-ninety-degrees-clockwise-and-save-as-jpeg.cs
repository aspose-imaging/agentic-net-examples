// HOW-TO: Rotate OTG Image 90 Degrees Clockwise and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input/input.otg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                var jpegOptions = new JpegOptions();
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
 * 1. When you need to convert scanned OTG documents to JPEG thumbnails for web preview.
 * 2. When generating portrait‑oriented JPEGs from landscape OTG graphics for mobile applications.
 * 3. When batch‑processing OTG files from a legacy system to standard JPEG format after correcting their orientation.
 * 4. When preparing OTG artwork for email attachments that require JPEG format and a specific rotation.
 * 5. When integrating OTG image handling into a C# service that outputs rotated JPEGs for a reporting dashboard.
 */
