// HOW-TO: Rotate a TIFF Image 180 Degrees Using Streams in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.tif";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                using (FileStream outputStream = File.OpenWrite(outputPath))
                {
                    image.Save(outputStream, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to programmatically flip scanned documents stored as TIFF files before archiving them.
 * 2. When a web service receives a TIFF image via a stream and must correct its orientation for downstream processing.
 * 3. When batch‑processing large multi‑page TIFFs on a server without loading the whole file into memory.
 * 4. When integrating with a legacy system that supplies TIFF data through a FileStream and expects the rotated result saved to another stream.
 * 5. When creating a document workflow that automatically rotates medical imaging TIFFs 180° to match viewing standards.
 */
