// HOW-TO: Convert First Ten DjVu Pages to Animated GIF with Frame Delay in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var stream = File.OpenRead(inputPath))
            {
                using (var djvu = new DjvuImage(stream))
                {
                    int pagesToConvert = Math.Min(djvu.PageCount, 10);
                    if (pagesToConvert == 0)
                    {
                        Console.Error.WriteLine("No pages to convert.");
                        return;
                    }

                    var firstPage = (DjvuPage)djvu.Pages[0];
                    var firstFrame = new GifFrameBlock((ushort)firstPage.Width, (ushort)firstPage.Height);
                    var graphics = new Graphics(firstFrame);
                    graphics.DrawImage(firstPage, new Point(0, 0));
                    int frameDelay = 200; // milliseconds
                    firstFrame.FrameTime = frameDelay;

                    using (var gifImage = new GifImage(firstFrame))
                    {
                        for (int i = 1; i < pagesToConvert; i++)
                        {
                            var page = (DjvuPage)djvu.Pages[i];
                            var frame = new GifFrameBlock((ushort)page.Width, (ushort)page.Height);
                            var g = new Graphics(frame);
                            g.DrawImage(page, new Point(0, 0));
                            frame.FrameTime = frameDelay;
                            gifImage.AddPage(frame);
                        }

                        var gifOptions = new GifOptions();
                        gifImage.Save(outputPath, gifOptions);
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
 * 1. When you need to generate a short animated preview of a multi‑page DjVu document for web thumbnails, this code creates a GIF from the first ten pages with a consistent frame delay.
 * 2. When automating a document‑processing pipeline that extracts key pages from scanned books and turns them into an animated GIF for quick visual inspection, the example shows how to load DjVu, limit pages, and set frame timing.
 * 3. When building a C# desktop application that lets users export selected DjVu pages as an animated GIF slideshow, the snippet demonstrates batch conversion and custom frame‑rate control.
 * 4. When integrating Aspose.Imaging into a server‑side service that converts large DjVu files to lightweight GIF animations for email attachments, the code illustrates handling missing files and creating the output directory.
 * 5. When creating a batch job that processes a folder of DjVu files and produces animated GIFs with a fixed 200 ms delay per frame for consistent playback across browsers, this example provides the core conversion logic.
 */
