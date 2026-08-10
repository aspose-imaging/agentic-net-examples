// HOW-TO: Batch Convert WebP Images to APNG with Fixed Frame Delay in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\WebpInput";
            string outputFolder = @"C:\ApngOutput";

            // Uniform frame delay in milliseconds
            uint frameDelay = 200; // 200 ms per frame

            // Get all .webp files in the input folder
            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with same name but .png extension (APNG)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG with uniform frame delay
                    image.Save(outputPath, new ApngOptions { DefaultFrameTime = frameDelay });
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
 * 1. When you need to convert a collection of animated WebP files into APNGs for browsers that only support PNG animation while keeping a consistent frame speed.
 * 2. When an automated build process must generate lightweight APNG assets from WebP source images for a game’s UI spritesheets.
 * 3. When a server‑side C# service has to batch‑process user‑uploaded WebP animations and store them as APNGs with a uniform 200 ms frame delay for consistent playback.
 * 4. When migrating a legacy design system, you can replace WebP animations with APNG equivalents across a folder to ensure compatibility with older image libraries.
 * 5. When creating a content pipeline that prepares animated icons, you can use this code to read each WebP file, apply the same frame timing, and output ready‑to‑use APNG files.
 */
