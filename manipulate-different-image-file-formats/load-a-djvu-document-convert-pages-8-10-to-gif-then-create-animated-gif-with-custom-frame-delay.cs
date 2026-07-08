using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/animated.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Prepare list for GIF frame blocks
                List<GifFrameBlock> frames = new List<GifFrameBlock>();

                // Pages 8‑10 (1‑based indexing)
                for (int pageNumber = 8; pageNumber <= 10; pageNumber++)
                {
                    int index = pageNumber - 1; // zero‑based index
                    if (index < 0 || index >= djvu.PageCount)
                    {
                        Console.Error.WriteLine($"Page {pageNumber} is out of range.");
                        return;
                    }

                    // Get the DjVu page as a raster image
                    DjvuPage djvuPage = (DjvuPage)djvu.Pages[index];

                    // Create a GIF frame block matching page size (ushort required)
                    GifFrameBlock frameBlock = new GifFrameBlock((ushort)djvuPage.Width, (ushort)djvuPage.Height);

                    // Draw the page onto the frame block
                    Graphics graphics = new Graphics(frameBlock);
                    graphics.DrawImage(djvuPage, new Rectangle(0, 0, djvuPage.Width, djvuPage.Height));

                    // Set custom frame delay (e.g., 200 ms)
                    frameBlock.FrameTime = 200;

                    frames.Add(frameBlock);
                }

                if (frames.Count == 0)
                {
                    Console.Error.WriteLine("No frames were created.");
                    return;
                }

                // Create animated GIF using the first frame
                using (GifImage gif = new GifImage(frames[0]))
                {
                    // Add remaining frames
                    for (int i = 1; i < frames.Count; i++)
                    {
                        gif.AddPage(frames[i]);
                    }

                    // Save animated GIF
                    gif.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to extract specific pages (e.g., pages 8‑10) from a multi‑page DjVu document and convert them into a single animated GIF for web preview.
 * 2. When an application must generate a lightweight GIF animation from high‑resolution DjVu scans to embed in email newsletters or social media posts.
 * 3. When a document‑management system requires converting selected DjVu pages into GIF frames with custom frame delays for creating slide‑show style previews.
 * 4. When a C# service automates the transformation of archival DjVu files into animated GIFs to improve accessibility for users who cannot view DjVu natively.
 * 5. When a developer wants to programmatically validate the existence of DjVu pages, rasterize them, and assemble them into an animated GIF using Aspose.Imaging for .NET.
 */