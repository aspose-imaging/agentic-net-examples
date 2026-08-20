// HOW-TO: Create Animated GIF From DjVu Pages 8 to 10 in C# (Aspose.Imaging for .NET)
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
                // Page indexes to convert (pages 8‑10, zero‑based indexes 7‑9)
                int[] pageIndexes = { 7, 8, 9 };
                if (pageIndexes.Length == 0) return;

                // Prepare first frame
                using (RasterImage firstPage = (RasterImage)djvu.Pages[pageIndexes[0]])
                {
                    using (GifImage gif = new GifImage(new GifFrameBlock((ushort)firstPage.Width, (ushort)firstPage.Height)))
                    {
                        // Draw first page onto the initial frame
                        Graphics graphics = new Graphics(gif);
                        graphics.DrawImage(firstPage, 0, 0);
                        gif.ActiveFrame.FrameTime = 200; // custom delay in ms

                        // Add remaining pages as frames
                        for (int i = 1; i < pageIndexes.Length; i++)
                        {
                            using (RasterImage page = (RasterImage)djvu.Pages[pageIndexes[i]])
                            {
                                gif.AddPage(page);
                                gif.ActiveFrame.FrameTime = 200; // same custom delay
                            }
                        }

                        // Save animated GIF
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
 * 1. When you need to display a short animation of selected DjVu pages on a website, you can convert pages 8‑10 to an animated GIF with a custom frame delay using C#.
 * 2. When generating preview thumbnails for a multi‑page DjVu document, creating an animated GIF of specific pages helps users quickly understand the content.
 * 3. When automating a workflow that extracts key pages from scanned books and bundles them into a lightweight GIF for email attachments, this code provides the conversion.
 * 4. When building a desktop application that visualizes selected DjVu pages as a looping animation for presentations, the sample shows how to set frame timing.
 * 5. When integrating document processing into a reporting system that needs to embed a short animated sequence of DjVu pages into PDFs or HTML reports, this approach creates the GIF programmatically.
 */
