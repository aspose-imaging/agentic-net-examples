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

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int[] pageIndexes = new int[] { 7, 9 }; // pages 8 and 10 (0‑based)

                using (RasterImage firstPage = (RasterImage)djvu.Pages[pageIndexes[0]])
                {
                    if (!firstPage.IsCached) firstPage.CacheData();

                    using (GifImage gif = new GifImage(new GifFrameBlock((ushort)firstPage.Width, (ushort)firstPage.Height)))
                    {
                        gif.AddPage(firstPage);

                        for (int i = 1; i < pageIndexes.Length; i++)
                        {
                            using (RasterImage page = (RasterImage)djvu.Pages[pageIndexes[i]])
                            {
                                if (!page.IsCached) page.CacheData();
                                gif.AddPage(page);
                            }
                        }

                        GifOptions gifOptions = new GifOptions
                        {
                            LoopsCount = 0 // infinite loop
                        };

                        gif.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract specific pages (e.g., pages 8 and 10) from a multi‑page Djvu file and present them as an animated GIF for web preview.
 * 2. When an e‑learning platform wants to convert selected Djvu lecture slides into a looping GIF animation to embed in course material.
 * 3. When a digital archive requires a lightweight, browser‑friendly representation of chosen Djvu pages for quick visual inspection without downloading the whole document.
 * 4. When a mobile app must generate an animated GIF thumbnail from particular Djvu pages to display in a gallery view with custom frame delay.
 * 5. When a document processing pipeline automates the transformation of selected Djvu pages into an infinite‑loop GIF for inclusion in marketing emails or social media posts.
 */