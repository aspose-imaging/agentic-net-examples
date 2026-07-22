using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.webp";
        string outputPath = "output.png";

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
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert user‑uploaded WebP images to PNG for compatibility with browsers that do not support WebP, they can use this Aspose.Imaging C# snippet to load the .webp file and save it as .png.
 * 2. When an automated batch job must generate PNG thumbnails from a collection of WebP assets stored on a file server, the code demonstrates how to verify file existence, create output folders, and perform the conversion with Aspose.Imaging.
 * 3. When a .NET web API has to process incoming image payloads and store them in a lossless format for archival, this example shows how to load a WebP image, handle errors, and save it as PNG using PngOptions.
 * 4. When integrating a content management system that only accepts PNG files, developers can employ this snippet to read WebP graphics, convert them to PNG, and ensure the target directory is created before saving.
 * 5. When building a desktop utility that validates image files before further processing, the code provides a straightforward way to check for the source WebP file, convert it to PNG with Aspose.Imaging, and capture any exceptions for logging.
 */