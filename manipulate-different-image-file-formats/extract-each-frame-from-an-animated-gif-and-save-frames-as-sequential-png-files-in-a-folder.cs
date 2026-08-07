using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputFolder = "output_frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gif.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    string outputPath = Path.Combine(outputFolder, $"frame_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    gif.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate individual PNG thumbnails from each frame of an animated GIF for use in a web gallery or preview carousel.
 * 2. When a video editing tool requires extracting every frame of a GIF animation to apply per‑frame filters or overlays in a C# application using Aspose.Imaging.
 * 3. When an e‑learning platform wants to convert animated instructional GIFs into separate PNG images for step‑by‑step slide presentations.
 * 4. When a mobile app needs to cache each frame of a GIF as a PNG file to improve rendering performance on low‑power devices.
 * 5. When a digital asset management system must archive the original frames of a GIF animation as lossless PNG files for compliance or version control.
 */