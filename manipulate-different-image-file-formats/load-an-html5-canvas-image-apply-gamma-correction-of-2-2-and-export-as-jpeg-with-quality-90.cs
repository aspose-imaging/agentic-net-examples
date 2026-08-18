// HOW-TO: Apply Gamma Correction to HTML Canvas and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.AdjustGamma(2.2f);

                FileCreateSource src = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions { Source = src, Quality = 90 };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert a web‑generated canvas image to a high‑quality JPEG for email attachments.
 * 2. When you must adjust the brightness perception of a canvas screenshot by applying a 2.2 gamma curve before storage.
 * 3. When an e‑commerce site wants to generate product thumbnails from HTML5 canvas drawings with consistent color rendering.
 * 4. When a reporting tool exports charts drawn on a canvas to JPEG files with specific compression quality for PDF embedding.
 * 5. When a mobile app backend processes user‑drawn canvas images, applies gamma correction, and saves them as JPEGs for efficient delivery.
 */
