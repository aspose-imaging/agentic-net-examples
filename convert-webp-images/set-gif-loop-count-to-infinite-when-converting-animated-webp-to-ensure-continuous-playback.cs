// HOW-TO: Convert Animated WebP to Infinite Loop GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.LoopsCount = 0; // infinite loop
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
 * 1. When you need to embed an animated WebP banner on a website that only supports GIFs and must play continuously without stopping.
 * 2. When creating a slideshow of product demos where the original animation is in WebP but the target platform requires looping GIFs for compatibility.
 * 3. When generating marketing emails that include animated graphics, converting WebP to an endlessly looping GIF ensures all email clients display the animation.
 * 4. When building a desktop application that displays user‑uploaded animated stickers, converting them to GIFs with infinite loops guarantees smooth playback on Windows forms.
 * 5. When processing a batch of animated assets for a mobile game, converting each WebP to a GIF with an infinite loop simplifies rendering on devices that lack WebP support.
 */
