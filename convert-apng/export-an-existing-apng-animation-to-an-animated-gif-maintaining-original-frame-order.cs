// HOW-TO: Convert APNG Animation To Animated GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                apng.Save(outputPath, options);
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
 * 1. When you need to display a web‑based APNG animation on platforms that only support animated GIFs, you can use this code to convert the file while keeping the original frame sequence.
 * 2. When a mobile app requires GIF assets for compatibility with older iOS or Android versions, the snippet lets you transform existing APNG assets into GIFs without losing animation timing.
 * 3. When automating a batch process that archives user‑uploaded APNG stickers as GIFs for email newsletters, this example shows how to load each APNG and save it as an animated GIF in C#.
 * 4. When integrating Aspose.Imaging into a server‑side service that generates preview thumbnails, you can first convert the APNG to GIF to simplify further processing or playback.
 * 5. When migrating a legacy graphics pipeline that only understands GIF animation, the code provides a straightforward way to preserve the original frame order while converting APNG files to GIF format.
 */
