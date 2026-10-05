// HOW-TO: Convert OTG to JPEG with 85% Quality in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.otg";
            string outputPath = "output/output.jpg";

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
                    Quality = 85
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
 * 1. When a developer needs to generate web‑friendly JPEG previews from high‑resolution OTG design files while controlling file size by setting the quality to 85 percent.
 * 2. When integrating a C# backend service that receives OTG uploads and must store them as compressed JPEGs for faster download and display in browsers.
 * 3. When creating an automated pipeline that converts a folder of OTG assets into JPEG thumbnails with a consistent quality setting for use in a digital asset management system.
 * 4. When migrating legacy OTG graphics to a modern CMS that only supports JPEG images, requiring precise quality control to balance visual fidelity and storage usage.
 * 5. When building a desktop utility that lets users select an OTG file and export it as a JPEG with 85 percent quality for printing or sharing on social media.
 */
