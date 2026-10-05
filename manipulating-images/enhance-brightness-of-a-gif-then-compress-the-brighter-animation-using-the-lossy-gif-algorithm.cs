// HOW-TO: How To Load And Re‑Save A Gif With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gif.Save(outputPath, gifOptions);
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
 * 1. When a web application must standardize uploaded animated GIFs to a consistent format before displaying them.
 * 2. When a batch job needs to reduce the file size of GIF animations by re‑encoding them with Aspose.Imaging options.
 * 3. When a desktop tool wants to apply further processing such as adding watermarks after loading a GIF and then save the result.
 * 4. When a server‑side service has to validate and rewrite GIF files to ensure they are not corrupted before serving them.
 * 5. When an automated pipeline converts user‑generated GIFs into a format compatible with legacy systems using C#.
 */
