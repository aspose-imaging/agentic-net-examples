// HOW-TO: Extract Third Frame From GIF and Save As Lossless WebP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.gif";
        string outputPath = "Output/frame3.webp";

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
                GifImage gif = img as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("Input file is not a GIF image.");
                    return;
                }

                if (gif.PageCount < 3)
                {
                    Console.Error.WriteLine("GIF does not contain at least three frames.");
                    return;
                }

                // Set the active frame to the third frame (index 2)
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[2];

                using (RasterImage frame = (RasterImage)gif.ActiveFrame)
                {
                    var webpOptions = new WebPOptions { Lossless = true };
                    frame.Save(outputPath, webpOptions);
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
 * 1. When you need to display a specific animation frame as a high‑quality static image for thumbnails or previews.
 * 2. When converting a GIF’s individual frame to a lossless WebP to reduce file size while preserving visual fidelity.
 * 3. When extracting a particular frame from an animated GIF for use in a PDF or report that only supports static images.
 * 4. When preparing assets for a web page that requires WebP support and you must isolate a single GIF frame for responsive design.
 * 5. When processing user‑uploaded GIFs and you want to store the third frame in a lossless WebP format for archival or further editing.
 */
