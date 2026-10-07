// HOW-TO: Flip TGA Image Vertically and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When you need to correct an upside‑down TGA sprite before embedding it in a game and deliver it as a JPEG for web preview.
 * 2. When converting legacy TGA textures from a graphics pipeline to JPEG thumbnails while ensuring the vertical orientation matches the original design.
 * 3. When processing scanned TGA files that were saved inverted and you must output a correctly oriented JPEG for client delivery.
 * 4. When automating batch conversion of TGA assets to JPEG for a mobile app, applying a vertical flip to match the device’s coordinate system.
 * 5. When integrating Aspose.Imaging in a C# service that receives TGA files, flips them vertically, and stores them as JPEGs for downstream image analysis.
 */
