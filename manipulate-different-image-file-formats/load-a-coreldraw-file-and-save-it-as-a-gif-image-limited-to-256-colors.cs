// HOW-TO: Convert CorelDRAW CDR to GIF with 256 Colors in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CorelDrawToGif
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output.gif";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    GifOptions options = new GifOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to display a CorelDRAW illustration on a web page that only supports GIF images.
 * 2. When you must reduce a CDR file to a 256‑color palette for compatibility with legacy systems.
 * 3. When you automate batch conversion of CDR assets to GIF for email newsletters.
 * 4. When you integrate image processing into a C# application that generates static GIF previews of vector designs.
 * 5. When you create thumbnails of CorelDRAW drawings for a product catalog that requires GIF format.
 */
