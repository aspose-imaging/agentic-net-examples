using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input GIF paths
            string[] inputPaths = { "gif1.gif", "gif2.gif", "gif3.gif" };
            // Hardcoded output path
            string outputPath = "merged.gif";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of first frames
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string inputPath in inputPaths)
            {
                using (GifImage gif = (GifImage)Image.Load(inputPath))
                {
                    RasterImage frame = (RasterImage)gif.Pages[0];
                    sizes.Add(frame.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create output GIF canvas bound to file
            Source outputSource = new FileCreateSource(outputPath, false);
            GifOptions gifOptions = new GifOptions() { Source = outputSource };
            using (RasterImage canvas = (RasterImage)Image.Create(gifOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (GifImage gif = (GifImage)Image.Load(inputPath))
                    {
                        RasterImage frame = (RasterImage)gif.Pages[0];
                        Rectangle bounds = new Rectangle(offsetX, 0, frame.Width, frame.Height);
                        canvas.SaveArgb32Pixels(bounds, frame.LoadArgb32Pixels(frame.Bounds));
                        offsetX += frame.Width;
                    }
                }

                // Save the bound image
                canvas.Save();
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
 * 1. When building a web application that receives scanned animated GIFs from users and needs to automatically correct their orientation with Aspose.Imaging for .NET before creating a single animated GIF preview.
 * 2. When generating product showcase animations from multiple camera‑captured GIF frames that may be slightly rotated, requiring deskew and side‑by‑side merging into one GIF for e‑commerce sites.
 * 3. When creating educational tutorials that combine several step‑by‑step GIF screenshots, each needing alignment correction, into a single animated GIF for online courses.
 * 4. When developing a social‑media tool that aggregates user‑uploaded GIF stickers, deskews them, and merges them into a composite animated GIF for sharing.
 * 5. When automating the preparation of marketing‑email assets by deskewing and stitching together multiple promotional GIFs into one animated GIF to reduce file size and improve visual consistency.
 */