// HOW-TO: Batch Convert WebP Images to GIF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputDirectory = @"C:\InputWebP";
        string outputDirectory = @"C:\OutputGif";

        try
        {
            foreach (var inputPath in Directory.GetFiles(inputDirectory, "*.webp"))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = new WebPImage(inputPath))
                {
                    image.Save(outputPath, new GifOptions());
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
 * 1. When you need to generate animated or static GIF previews for a large set of WebP assets stored on a server.
 * 2. When migrating a web application's image library from WebP to GIF to support browsers that do not handle WebP.
 * 3. When creating GIF versions of user‑uploaded WebP files for email newsletters that require GIF format.
 * 4. When automating a nightly job that converts newly added WebP graphics into GIFs for a digital signage system.
 * 5. When building a tool that processes a folder of WebP icons and outputs GIFs for use in legacy Windows applications.
 */
