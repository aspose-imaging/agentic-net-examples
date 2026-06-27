using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
            string inputPath = "sample.djvu";
            string outputPath = "animated.gif";
            string tempDir = "temp_frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            // Ensure temporary directory exists
            Directory.CreateDirectory(tempDir);

            // Load DjVu document and export pages 7‑9 as individual GIF files
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int[] pagesToExport = { 7, 8, 9 };
                foreach (int pageNumber in pagesToExport)
                {
                    if (pageNumber < 1 || pageNumber > djvuImage.PageCount)
                        continue; // skip invalid page numbers

                    var djvuPage = djvuImage.Pages[pageNumber - 1];
                    string tempPath = Path.Combine(tempDir, $"page{pageNumber}.gif");
                    djvuPage.Save(tempPath, new GifOptions());
                }
            }

            // Load the exported GIF frames as RasterImage objects
            var rasterFrames = Directory.GetFiles(tempDir, "*.gif")
                .Select(p => (RasterImage)Image.Load(p))
                .ToArray();

            if (rasterFrames.Length == 0)
            {
                Console.Error.WriteLine("No frames were exported.");
                return;
            }

            // Create an animated GIF using the first frame and add the remaining frames
            using (GifImage animatedGif = new GifImage(new GifFrameBlock(rasterFrames[0])))
            {
                for (int i = 1; i < rasterFrames.Length; i++)
                {
                    animatedGif.AddPage(rasterFrames[i]);
                }

                // Save the animated GIF
                animatedGif.Save(outputPath);
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
 * 1. When a developer needs to extract specific pages (e.g., pages 7‑9) from a multi‑page DjVu document and create an animated GIF for web preview, they can use this code.
 * 2. When an archival system must convert selected DjVu pages into GIF frames and combine them into a single animated GIF to embed in an e‑learning module, this snippet provides the required workflow.
 * 3. When a digital publishing platform wants to generate a lightweight animated preview of scanned book sections stored as DjVu files, the code shows how to export pages to GIF and assemble them.
 * 4. When a document‑management application requires on‑the‑fly conversion of DjVu pages to an animated GIF for email attachments, the example demonstrates loading, saving, and merging the frames in C#.
 * 5. When a QA engineer needs to automate testing of DjVu‑to‑GIF conversion and verify that pages 7‑9 render correctly as an animated GIF, this code offers a repeatable solution.
 */