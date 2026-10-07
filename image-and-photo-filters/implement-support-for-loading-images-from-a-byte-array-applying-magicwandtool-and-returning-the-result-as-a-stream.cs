// HOW-TO: Load Image from Byte Array, Apply Magic Wand, Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(imageBytes))
            using (RasterImage image = (RasterImage)Image.Load(inputStream))
            {
                // Apply MagicWand selection at point (10,10) and apply mask
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Apply();

                using (MemoryStream outputStream = new MemoryStream())
                {
                    image.Save(outputStream, new PngOptions());
                    File.WriteAllBytes(outputPath, outputStream.ToArray());
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
 * 1. When you need to process an uploaded image stored in memory, select a region with the Magic Wand tool and output a PNG without writing intermediate files.
 * 2. When integrating Aspose.Imaging into a web API that receives image bytes, you can apply a Magic Wand selection to isolate an object and return the edited image as a stream.
 * 3. When converting raw JPEG data retrieved from a database into a masked PNG for further analysis, this code loads the bytes, applies a Magic Wand mask, and saves the result.
 * 4. When building a desktop application that lets users click a point to auto‑select similar colors and export the selection as a transparent PNG, the example demonstrates the required steps.
 * 5. When automating batch processing of images stored in a cloud blob, you can read each file into a byte array, apply Magic Wand selection, and write the processed PNG back to storage.
 */
