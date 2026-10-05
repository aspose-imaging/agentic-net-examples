// HOW-TO: Extract GIF Frames to PNG and Log Transparency Status in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputGifPath = "input.gif";
            string outputDir = "output";

            if (!File.Exists(inputGifPath))
            {
                Console.Error.WriteLine($"File not found: {inputGifPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputGifPath))
            {
                int frameCount = gif.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    string outputPath = Path.Combine(outputDir, $"frame_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions();
                    gif.Save(outputPath, pngOptions);

                    using (Aspose.Imaging.RasterImage png = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
                    {
                        bool hasTransparency = png.HasTransparentColor;
                        Console.WriteLine($"Frame {i}: Transparent = {hasTransparency}");
                    }
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
 * 1. When you need to verify that each frame extracted from an animated GIF retains its transparency after conversion to PNG for quality‑assurance testing.
 * 2. When a QA pipeline must automatically generate PNG assets from GIF animations and record whether each image contains a transparent color.
 * 3. When you are building a content‑management workflow that extracts individual frames from GIFs, saves them as PNGs, and logs transparency to ensure correct rendering on web pages.
 * 4. When a developer wants to programmatically inspect the alpha channel of every frame in a GIF to detect loss of transparency during batch conversion.
 * 5. When creating automated reports that list the transparency status of PNG files produced from GIF frames for compliance with design guidelines.
 */
