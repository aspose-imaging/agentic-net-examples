// HOW-TO: Flip PNG Vertically Using MemoryStream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var fileStream = File.OpenRead(inputPath))
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                using (Image image = Image.Load(memoryStream))
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    memoryStream.SetLength(0);
                    image.Save(memoryStream, new PngOptions());
                }

                memoryStream.Position = 0;
                using (var outFile = File.Create(outputPath))
                {
                    memoryStream.CopyTo(outFile);
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
 * 1. When you need to vertically mirror a PNG image stored in memory before saving it to disk in a C# application.
 * 2. When processing uploaded PNG files in a web service and you must flip them without creating temporary files.
 * 3. When generating thumbnails that require a top‑to‑bottom inversion of PNG graphics in a background job.
 * 4. When converting images received from a camera sensor that provides upside‑down PNG data and you need to correct orientation in .NET.
 * 5. When implementing an image editor that applies a vertical flip to a PNG loaded from a stream and returns the modified stream to the caller.
 */
