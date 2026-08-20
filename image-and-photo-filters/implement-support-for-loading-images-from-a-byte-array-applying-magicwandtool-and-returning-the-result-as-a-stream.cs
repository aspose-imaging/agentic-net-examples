// HOW-TO: Load PNG From Array, Apply Magic Wand Selection, and Save To Stream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(imageBytes))
            {
                using (RasterImage image = (RasterImage)Image.Load(inputStream))
                {
                    MagicWandTool
                        .Select(image, new MagicWandSettings(50, 50))
                        .Apply();

                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha
                        };
                        image.Save(outputStream, pngOptions);
                        File.WriteAllBytes(outputPath, outputStream.ToArray());
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
 * 1. When you need to process an uploaded PNG image stored in memory, apply a magic‑wand selection, and return the edited image without writing intermediate files.
 * 2. When a web API receives image data as a byte array, you can use Aspose.Imaging to select regions based on color tolerance and stream the result back to the client.
 * 3. When converting raw image bytes from a database into a PNG with transparency after a magic‑wand cutout, this code loads, edits, and saves the image in a single memory stream.
 * 4. When building a desktop tool that lets users click a point to auto‑select similar pixels in a PNG and then export the selection as a new file, the example demonstrates the full load‑process‑save workflow.
 * 5. When integrating image processing into a background service that must avoid disk I/O, the snippet shows how to read, modify with MagicWandTool, and write the PNG entirely in memory.
 */
