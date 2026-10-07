// HOW-TO: How to Dither a GIF Animation and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output\\output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                if (img is RasterImage raster)
                {
                    raster.Dither((DitheringMethod)0, 8, null);
                }

                var gifOptions = new GifOptions();
                img.Save(outputPath, gifOptions);
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
 * 1. When you need to reduce the color depth of an animated GIF for web delivery while preserving visual quality, you can dither each frame using Aspose.Imaging in C#.
 * 2. When converting a high‑resolution GIF created from video frames to a smaller palette for email attachments, dithering helps maintain detail without increasing file size.
 * 3. When preparing a GIF for display on devices that only support 256 colors, applying a dithering algorithm ensures smoother gradients across the animation.
 * 4. When automating a batch process that optimizes user‑generated GIFs before uploading to a content management system, you can programmatically dither and re‑save each file with Aspose.Imaging.
 * 5. When retro‑stylizing a modern animation by applying a limited color palette with dithering, the code lets you generate a nostalgic GIF directly from C#.
 */
