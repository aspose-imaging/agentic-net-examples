// HOW-TO: Convert PNG to JPEG with Quality Setting in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 90;
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate smaller JPEG thumbnails from high‑resolution PNG assets for web pages.
 * 2. When you must batch‑process user‑uploaded PNG images and store them as compressed JPEGs to save disk space.
 * 3. When integrating an image conversion step into a C# service that prepares product photos for e‑commerce platforms.
 * 4. When converting PNG screenshots to JPEG format before sending them via email to reduce attachment size.
 * 5. When migrating legacy PNG graphics to JPEG for compatibility with older browsers while controlling output quality.
 */
