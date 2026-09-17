// HOW-TO: Convert APNG to Animated GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.apng";
        string outputPath = "output/output.gif";

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
                GifOptions gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to serve animated images to browsers that only support GIF, they can convert APNG files to GIF with Aspose.Imaging in C#.
 * 2. When an e‑learning platform wants to reuse existing APNG assets in legacy mobile apps that require GIF animation, this code provides a quick conversion routine.
 * 3. When a marketing automation script generates product demos as APNG but the email client only renders GIF, the conversion ensures the animation is displayed correctly.
 * 4. When a game developer extracts sprite animations stored as APNG and needs to embed them into a GIF‑based sprite sheet for older game engines, this snippet handles the format change.
 * 5. When a content‑management system batch‑processes user‑uploaded APNG files and must store them as GIF for uniform thumbnail generation, the code automates the conversion in C#.
 */
