// HOW-TO: Convert WebP to GIF and Verify Output File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

namespace WebPToGifConverter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var gifOptions = new GifOptions();
                    image.Save(outputPath, gifOptions);
                }

                if (File.Exists(outputPath))
                {
                    Console.WriteLine("GIF file created successfully.");
                }
                else
                {
                    Console.Error.WriteLine("Failed to create GIF file.");
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
 * 1. When you need to batch‑convert user‑uploaded WebP images to GIFs for compatibility with older browsers in a .NET web application.
 * 2. When you must generate animated GIF previews from WebP assets and confirm the files were saved correctly on the server.
 * 3. When integrating Aspose.Imaging into a C# service that transforms product photos from WebP to GIF while checking for successful file creation.
 * 4. When automating a migration of a media library from WebP to GIF format and need to log any conversion failures.
 * 5. When building a desktop utility that converts single WebP files to GIF and validates the output before further processing.
 */
