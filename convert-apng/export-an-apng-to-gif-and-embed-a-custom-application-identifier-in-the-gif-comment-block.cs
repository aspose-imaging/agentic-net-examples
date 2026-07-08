using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image apngImage = Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                apngImage.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to convert animated PNGs created by a design tool into GIFs for compatibility with older browsers while tagging the file with the application name for tracking.
 * 2. When a mobile app generates APNG stickers and must export them as GIFs for messaging platforms that only accept GIFs, embedding a custom identifier to trace the source app.
 * 3. When an e‑learning platform converts animated instructional graphics from APNG to GIF to embed in PowerPoint slides, adding a comment block that records the content management system version.
 * 4. When a marketing automation system processes user‑uploaded APNG banners and converts them to GIFs for email newsletters, inserting a custom application ID in the GIF metadata for analytics.
 * 5. When a game developer exports in‑game animated icons from APNG to GIF for use in a legacy UI engine, and includes a comment with the game engine’s build number for debugging.
 */