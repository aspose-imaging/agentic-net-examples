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
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.gif";

        // Verify input file exists
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
                // Pages to extract (7‑9, 1‑based indexing)
                int[] pagesToExtract = new int[] { 7, 8, 9 };
                List<RasterImage> rasterFrames = new List<RasterImage>();

                foreach (int pageNumber in pagesToExtract)
                {
                    // DjvuImage.Pages is zero‑based
                    if (pageNumber < 1 || pageNumber > djvuImage.PageCount)
                        continue; // skip invalid page numbers

                    var djvuPage = djvuImage.Pages[pageNumber - 1];

                    // Save the page to a memory stream as PNG, then load as RasterImage
                    using (MemoryStream ms = new MemoryStream())
                    {
                        djvuPage.Save(ms, new PngOptions());
                        ms.Position = 0;
                        var raster = (RasterImage)Image.Load(ms);
                        rasterFrames.Add(raster);
                    }
                }

                if (rasterFrames.Count == 0)
                {
                    Console.Error.WriteLine("No pages were extracted.");
                    return;
                }

                // Create animated GIF using the first frame
                using (GifImage gifImage = new GifImage(new GifFrameBlock(rasterFrames[0])))
                {
                    // Add remaining frames
                    for (int i = 1; i < rasterFrames.Count; i++)
                    {
                        gifImage.AddPage(new GifFrameBlock(rasterFrames[i]));
                    }

                    // Save the animated GIF
                    GifOptions gifOptions = new GifOptions();
                    gifImage.Save(outputPath, gifOptions);
                }

                // Dispose temporary raster frames
                foreach (var frame in rasterFrames)
                {
                    frame.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}