using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    KeepMetadata = true
                };

                cmx.Save(outputPath, jpegOptions);
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
 * 1. When a graphic design workflow requires converting legacy CorelDRAW CMX files to web‑friendly JPEG images while keeping the original EXIF orientation metadata intact.
 * 2. When an e‑commerce platform needs to batch‑process product illustrations stored as CMX and generate correctly oriented JPEG thumbnails for faster page loads.
 * 3. When a digital asset management system must ingest CMX artwork and store it as JPEGs without losing camera orientation data for downstream printing pipelines.
 * 4. When a mobile app that displays user‑uploaded designs must transform CMX files into JPEGs on the server while preserving orientation tags for accurate on‑screen rendering.
 * 5. When a document conversion service automates the migration of archived CMX graphics to JPEG format and needs to retain EXIF orientation to maintain visual consistency across devices.
 */