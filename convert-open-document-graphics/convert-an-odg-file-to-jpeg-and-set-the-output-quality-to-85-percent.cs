// HOW-TO: Convert ODG to JPEG with 85% Quality Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑ready JPEG thumbnails from OpenDocument graphics files while controlling compression level.
 * 2. When an application must batch‑process ODG diagrams and store them as high‑quality JPEGs for email attachments.
 * 3. When integrating a document management system that receives ODG uploads and must display them as JPEG previews in a browser.
 * 4. When converting engineering drawings saved as ODG into JPEG format for inclusion in reports with a specific 85 percent quality setting.
 * 5. When automating the migration of legacy ODG assets to JPEG for a content‑delivery pipeline that requires consistent image quality.
 */
