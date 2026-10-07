// HOW-TO: Convert WebP Image to GIF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.webp";
            string outputPath = "Output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    webp.Save(outputPath, gifOptions);
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
 * 1. When you need to display a WebP picture on a platform that only supports GIF animations, you can convert it with Aspose.Imaging in C#.
 * 2. When processing user‑uploaded WebP files on a web server and you must generate GIF thumbnails for email previews, this code provides a quick conversion.
 * 3. When migrating legacy assets from a mobile app that stores images as WebP to a desktop application that requires GIF for slide shows, the snippet automates the format change.
 * 4. When creating an automated batch job that extracts frames from animated WebP files and saves them as GIFs for compatibility with older browsers, the code can be integrated into the pipeline.
 * 5. When building a content‑management system that validates uploaded images and needs to fallback to GIF if the WebP cannot be rendered, this conversion routine ensures a safe alternative.
 */
