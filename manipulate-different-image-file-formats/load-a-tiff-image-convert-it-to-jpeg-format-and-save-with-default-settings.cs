// HOW-TO: Convert TIFF Image to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input/sample.tif";
                string outputPath = "Output/sample.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        image.Save(outputPath, jpegOptions);
                    }
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
 * 1. When you need to shrink large multi‑page TIFF scans for faster web display by converting them to JPEG files in a C# application.
 * 2. When a document management system stores incoming scans as TIFF and you must generate JPEG thumbnails for preview screens using Aspose.Imaging.
 * 3. When an e‑commerce platform receives product photos in TIFF format and you want to automatically convert them to JPEG to reduce storage costs in .NET.
 * 4. When a Windows service processes scanned invoices and must save them as JPEG for compatibility with downstream OCR tools.
 * 5. When a desktop utility needs to batch‑convert user‑selected TIFF files to JPEG with default compression settings without manual intervention.
 */
