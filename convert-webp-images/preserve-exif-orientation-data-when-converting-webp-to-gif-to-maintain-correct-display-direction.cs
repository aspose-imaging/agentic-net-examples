// HOW-TO: Convert WebP to GIF while Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.webp";
            string outputPath = "Output/result.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("Input is not a WebP image.");
                    return;
                }

                using (GifOptions gifOptions = new GifOptions())
                {
                    gifOptions.ExifData = webp.ExifData;
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
 * 1. When you need to display user‑uploaded WebP photos in a legacy web page that only supports GIF but must keep the original rotation.
 * 2. When generating GIF previews from WebP assets while ensuring the images appear upright on devices that rely on EXIF orientation data.
 * 3. When converting product images from WebP to GIF for email newsletters and you must retain the correct orientation without manually editing each file.
 * 4. When building a batch‑processing tool that transforms a folder of WebP files into GIFs for a content management system while preserving metadata for SEO.
 * 5. When creating a cross‑platform game asset pipeline that requires GIF sprites extracted from WebP textures and needs the original orientation to match design specifications.
 */
