// HOW-TO: Rotate EMF Image 90 Degrees and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

namespace ImageRotationExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.emf";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (EmfImage image = (EmfImage)Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to display a legacy EMF diagram in a web page that only supports PNG, you can rotate it 90° and convert it to PNG using C#.
 * 2. When generating printable reports that require all graphics to be oriented consistently, you can rotate EMF charts by 90 degrees and save them as PNG files for inclusion.
 * 3. When automating a batch process that receives EMF icons from a third‑party tool and must output correctly oriented PNG thumbnails for a mobile app.
 * 4. When fixing orientation issues caused by EMF files created in landscape mode before uploading them to a content management system that expects portrait PNG images.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded EMF files to PNG while ensuring the image is rotated to match the desired layout.
 */
