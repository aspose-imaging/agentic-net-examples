using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "Output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 3, 4, 5 })
                };

                djvuImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to use C# and Aspose.Imaging to extract pages 4‑6 from a multi‑page DjVu file and create an animated GIF with a 100 ms frame delay for embedding in a web tutorial.
 * 2. When an e‑learning platform wants to convert scanned lecture notes stored as DjVu into a lightweight GIF slideshow, applying a custom 100 ms delay between frames to improve mobile loading speed.
 * 3. When a digital archivist must generate a preview animation of selected DjVu pages, using Aspose.Imaging to produce a GIF that loops with a consistent 100 ms frame interval for quick manuscript browsing.
 * 4. When a marketing application automatically transforms specific pages of a DjVu product catalog into a looping GIF banner, setting a 100 ms delay per frame to create a smooth visual effect.
 * 5. When a document‑processing pipeline in C# batch‑converts chosen DjVu pages into GIF animations for inclusion in email newsletters, ensuring each frame displays for exactly 100 ms.
 */