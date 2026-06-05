using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\pages4to6.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            using (GifOptions gifOptions = new GifOptions())
            {
                // Select pages 4‑6 (1‑based indexing) for export
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(4, 6));

                // Set custom frame delay of 100 ms
                gifOptions.FullFrame = true;
                gifOptions.MultiPageOptions.Mode = MultiPageMode.TimeInterval;
                gifOptions.MultiPageOptions.TimeInterval = new TimeInterval(0, 100);

                djvu.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract a specific range of pages (e.g., pages 4‑6) from a multi‑page DjVu document and create an animated GIF for web preview.
 * 2. When an application must convert selected DjVu pages into a GIF animation with a custom 100 ms frame delay to control playback speed.
 * 3. When building a document‑to‑media pipeline that reads DjVu files from disk, processes them in C# using Aspose.Imaging, and outputs a lightweight GIF for email attachments.
 * 4. When a digital archive system requires converting only certain DjVu pages into a GIF while preserving the original order and setting a uniform time interval between frames.
 * 5. When a developer wants to programmatically generate a short animated GIF from a DjVu e‑book chapter, ensuring each frame displays for exactly 0.1 seconds for consistent user experience.
 */