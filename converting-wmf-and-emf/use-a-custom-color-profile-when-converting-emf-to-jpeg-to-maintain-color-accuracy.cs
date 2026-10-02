// HOW-TO: Convert EMF to JPEG with Custom ICC Color Profile in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/sample.jpg";
            string iccProfilePath = "Input/custom.icc";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (FileStream iccStream = File.OpenRead(iccProfilePath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.RgbColorProfile = new StreamSource(iccStream);
                        image.Save(outputPath, jpegOptions);
                    }
                }
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
 * 1. When you need to preserve the exact colors of a vector EMF logo while delivering it as a JPEG for web pages, you can apply a custom ICC profile during conversion.
 * 2. When generating printable JPEG thumbnails from EMF drawings in a desktop application, using a specific color profile ensures the thumbnails match the brand’s color standards.
 * 3. When migrating legacy EMF assets to a JPEG‑based digital asset management system, applying the original ICC profile prevents color shifts caused by default sRGB conversion.
 * 4. When an automated report generator creates JPEG charts from EMF diagrams and must comply with a client‑specified color space, the code embeds the required ICC profile.
 * 5. When building a C# service that converts user‑uploaded EMF files to JPEG for email attachments, using a custom ICC profile guarantees consistent color reproduction across different email clients.
 */
