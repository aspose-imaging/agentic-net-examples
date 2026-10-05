// HOW-TO: Re-Encode GIF with Aspose.Imaging to Reduce File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

public class Program
{
    public static void Main(string[] args)
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

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                }

                GifOptions saveOptions = new GifOptions();
                gif.Save(outputPath, saveOptions);
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
 * 1. When you need to shrink an animated GIF for faster web page loading without changing its visual content.
 * 2. When you want to standardize GIF frames by resetting the active frame before saving to ensure compatibility across browsers.
 * 3. When you need to batch‑process GIF files on a server and re‑save them using Aspose.Imaging to apply default lossy compression.
 * 4. When you are building a C# application that must validate the existence of a GIF, load it, and output a new file in a specific directory.
 * 5. When you want to use Aspose.Imaging’s GifOptions to control GIF saving parameters while preserving the original animation sequence.
 */
