// HOW-TO: Convert Animated WebP to GIF with Infinite Loop in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    gifOptions.LoopsCount = 0;
                    image.Save(outputPath, gifOptions);
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
 * 1. When you need to display an animated WebP banner on platforms that only support GIF, you can convert it while preserving all frames and setting the animation to loop forever.
 * 2. When a mobile app requires an endlessly looping GIF for a loading spinner but the source assets are stored as animated WebP, this code transforms the source without losing animation.
 * 3. When migrating a website’s animated graphics from WebP to GIF for email newsletters that don’t recognize WebP, you can keep the animation intact and ensure continuous playback.
 * 4. When creating a slideshow where each slide is an animated WebP and the presentation tool only accepts GIFs, this snippet converts each file and forces an infinite loop.
 * 5. When automating a batch process that archives animated WebP files as GIFs for legacy systems, the code guarantees all frames are retained and the resulting GIF repeats indefinitely.
 */
