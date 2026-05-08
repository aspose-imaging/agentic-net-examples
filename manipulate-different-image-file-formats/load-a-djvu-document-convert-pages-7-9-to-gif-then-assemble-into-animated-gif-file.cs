using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.gif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Pages 7‑9 (1‑based indexing)
                int startPage = 7;
                int endPage = 9;

                // Guard against documents with fewer pages
                if (djvuImage.PageCount < startPage)
                {
                    Console.Error.WriteLine("DjVu document does not contain the required pages.");
                    return;
                }

                // Prepare GIF image
                GifImage gifImage = null;

                for (int pageNumber = startPage; pageNumber <= endPage && pageNumber <= djvuImage.PageCount; pageNumber++)
                {
                    // DjVu pages collection is zero‑based
                    var djvuPage = djvuImage.Pages[pageNumber - 1];

                    // Save the page to a memory stream as PNG (any raster format works)
                    using (var ms = new MemoryStream())
                    {
                        djvuPage.Save(ms, new PngOptions());
                        ms.Position = 0;

                        // Load the raster image from the memory stream
                        using (var rasterImage = (RasterImage)Image.Load(ms))
                        {
                            if (gifImage == null)
                            {
                                // First frame: create GifImage with a GifFrameBlock
                                var firstBlock = new GifFrameBlock(rasterImage);
                                gifImage = new GifImage(firstBlock);
                            }
                            else
                            {
                                // Subsequent frames: add as pages
                                gifImage.AddPage(rasterImage);
                            }
                        }
                    }
                }

                if (gifImage == null)
                {
                    Console.Error.WriteLine("No frames were added to the animated GIF.");
                    return;
                }

                // Save the animated GIF
                gifImage.Save(outputPath);
                gifImage.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}