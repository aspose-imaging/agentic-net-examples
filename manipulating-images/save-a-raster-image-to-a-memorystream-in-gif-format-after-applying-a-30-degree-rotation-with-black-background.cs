// HOW-TO: Rotate Image 30 Degrees And Save As GIF To MemoryStream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate 30 degrees with black background, resize proportionally
                image.Rotate(30f, true, Aspose.Imaging.Color.Black);

                using (MemoryStream ms = new MemoryStream())
                {
                    var gifOptions = new GifOptions();
                    image.Save(ms, gifOptions);
                    File.WriteAllBytes(outputPath, ms.ToArray());
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
 * 1. When you need to display a rotated PNG as a GIF on a web page without writing the file to disk first.
 * 2. When you must generate a GIF thumbnail that is rotated by a specific angle and store it in memory for further processing or transmission.
 * 3. When an API requires a GIF payload with a black background after rotation, and you want to create it directly from a raster image in C#.
 * 4. When you are building a batch job that converts user‑uploaded PNGs to rotated GIFs and streams them to another service.
 * 5. When you want to apply a 30‑degree rotation with a solid background to an image and keep the result in a MemoryStream for embedding in emails or PDFs.
 */
