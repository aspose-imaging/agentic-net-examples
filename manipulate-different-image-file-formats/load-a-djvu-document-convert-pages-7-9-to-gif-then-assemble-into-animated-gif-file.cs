using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.djvu";
            string outputPath = @"C:\Images\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                GifImage gifImage = null;
                bool firstFrame = true;

                // Iterate through all pages and process pages 7‑9
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    // DjVu pages are 1‑based; adjust index accordingly
                    int pageNumber = i + 1;
                    if (pageNumber < 7 || pageNumber > 9)
                        continue;

                    // Retrieve the page as a raster image
                    RasterImage rasterPage = (RasterImage)djvuImage.Pages[i];

                    // Create a GIF frame from the raster page
                    GifFrameBlock frameBlock = new GifFrameBlock(rasterPage);

                    if (firstFrame)
                    {
                        // Initialize the animated GIF with the first frame
                        gifImage = new GifImage(frameBlock);
                        firstFrame = false;
                    }
                    else
                    {
                        // Add subsequent frames
                        gifImage.AddPage(frameBlock);
                    }
                }

                if (gifImage != null)
                {
                    // Save the animated GIF
                    gifImage.Save(outputPath);
                    gifImage.Dispose();
                }
                else
                {
                    Console.Error.WriteLine("Pages 7‑9 were not found in the DjVu document.");
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
 * 1. When a developer needs to extract pages 7‑9 from a multi‑page DjVu document and create an animated GIF for web preview, they can use this C# Aspose.Imaging code.
 * 2. When a digital archive system must convert selected DjVu pages into a lightweight GIF animation for email newsletters, the example shows how to load, rasterize, and assemble the frames.
 * 3. When an e‑learning platform wants to generate a short animated tutorial from specific pages of a DjVu textbook, this code demonstrates converting those pages to GIF frames in .NET.
 * 4. When a document‑management workflow requires turning a subset of scanned DjVu pages into an animated GIF for quick visual inspection, the snippet provides the necessary C# operations.
 * 5. When a mobile app needs to display a looping preview of pages 7‑9 from a DjVu file without loading the entire document, this example shows how to create an animated GIF using Aspose.Imaging for .NET.
 */