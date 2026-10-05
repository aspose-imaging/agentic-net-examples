// HOW-TO: Convert 16‑Bit DNG to 8‑Bit JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dng.DngImage dng = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 90
                };

                dng.Save(outputPath, jpegOptions);
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
 * 1. When a photographer needs to generate web‑ready JPEG previews from high‑resolution 16‑bit DNG files using C#.
 * 2. When an e‑commerce platform must automatically convert raw camera images to smaller JPEG thumbnails for product listings.
 * 3. When a digital asset management system requires batch processing to reduce storage size by converting raw DNGs to 8‑bit JPEGs.
 * 4. When a mobile app backend needs to serve fast‑loading images by converting DNG uploads to JPEG with controlled quality.
 * 5. When a scientific imaging workflow wants to archive raw 16‑bit data while providing 8‑bit JPEG copies for quick visual inspection.
 */
