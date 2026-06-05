using System;
using System.IO;
using Aspose.Imaging;
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

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int[] pageIndexes = new int[] { 7, 8, 9 };

                RasterImage firstPage = (RasterImage)djvu.Pages[pageIndexes[0]];
                if (!firstPage.IsCached) firstPage.CacheData();

                using (GifFrameBlock firstBlock = new GifFrameBlock((ushort)firstPage.Width, (ushort)firstPage.Height))
                {
                    Graphics graphics = new Graphics(firstBlock);
                    graphics.DrawImage(firstPage, new Rectangle(0, 0, firstPage.Width, firstPage.Height));
                    firstBlock.FrameTime = 200;

                    using (GifImage gif = new GifImage(firstBlock))
                    {
                        for (int i = 1; i < pageIndexes.Length; i++)
                        {
                            RasterImage page = (RasterImage)djvu.Pages[pageIndexes[i]];
                            if (!page.IsCached) page.CacheData();

                            using (GifFrameBlock block = new GifFrameBlock((ushort)page.Width, (ushort)page.Height))
                            {
                                Graphics g = new Graphics(block);
                                g.DrawImage(page, new Rectangle(0, 0, page.Width, page.Height));
                                block.FrameTime = 200;

                                gif.AddPage(block);
                            }
                        }

                        gif.Save(outputPath);
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
 * 1. When a developer needs to extract pages 8‑10 from a multi‑page DjVu file and create a lightweight animated GIF for web preview, this C# Aspose.Imaging code provides a ready‑to‑use solution.
 * 2. When an e‑learning platform wants to convert selected DjVu lecture slides into an animated GIF with a uniform 200 ms frame delay for smooth slide transitions, the snippet demonstrates the required image‑processing steps.
 * 3. When a digital archive requires batch conversion of high‑resolution DjVu pages into a single animated GIF to embed in a mobile app, the example shows how to cache raster data and assemble GifFrameBlocks in C#.
 * 4. When a marketing tool needs to generate a short looping animation from specific DjVu pages (e.g., product catalog pages 8‑10) for social‑media sharing, this code illustrates setting custom frame times using Aspose.Imaging for .NET.
 * 5. When a document‑management system must produce a preview animation of selected DjVu pages for quick visual inspection without loading the entire file, the example outlines loading, caching, and converting pages to an animated GIF with controlled frame delay.
 */