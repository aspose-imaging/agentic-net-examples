// HOW-TO: Convert DNG Raw Photo to Lossless JPEG2000 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\photo.dng";
        string outputPath = "Output\\photo.jp2";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;

                using (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image jpeg2000Image = new Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image(dngImage))
                {
                    var options = new Jpeg2000Options
                    {
                        Irreversible = false // lossless compression
                    };
                    jpeg2000Image.Save(outputPath, options);
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
 * 1. When a photographer needs to archive raw DNG images in a lossless JPEG2000 format for long‑term storage while preserving full color detail.
 * 2. When a web service must deliver high‑quality, bandwidth‑efficient images by converting raw camera files to JPEG2000 without any quality loss.
 * 3. When a digital asset management system imports DNG files and stores them as JPEG2000 to ensure compatibility with viewers that support JP2.
 * 4. When a batch processing tool needs to demosaic raw sensor data and output a lossless JPEG2000 for downstream image analysis pipelines.
 * 5. When a developer wants to integrate Aspose.Imaging into a C# application to transform raw photographs into a standardized, lossless format for archival or printing workflows.
 */
