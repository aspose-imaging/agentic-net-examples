// HOW-TO: Rotate JPEG Image 120 Degrees With White Background Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (RasterImage image = (RasterImage)Image.Load(inputStream))
                {
                    image.Rotate(120f, true, Aspose.Imaging.Color.White);

                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        JpegOptions jpegOptions = new JpegOptions();
                        image.Save(outputStream, jpegOptions);
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
 * 1. When you need to programmatically rotate a JPEG photo by a non‑right angle and fill the empty corners with white before saving it to another stream.
 * 2. When an application processes uploaded images from a web request, rotates them 120° to correct orientation, and returns the modified JPEG to the client.
 * 3. When a batch job reads JPEG files from a file system, applies a custom rotation with a white background to match a printing layout, and writes the results back to disk.
 * 4. When you want to integrate Aspose.Imaging in a C# service that streams JPEG data from a database, rotates it, and stores the transformed image without creating temporary files.
 * 5. When a desktop tool must load a JPEG from a memory stream, rotate it for a slideshow effect, and export the rotated image using JPEG options.
 */
