// HOW-TO: Convert DjVu Pages to Animated GIF with Dithering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrWhiteSpace(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            List<RasterImage> frames = new List<RasterImage>();

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                foreach (var page in djvu.Pages)
                {
                    RasterImage raster = (RasterImage)page;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        raster.Save(ms, new PngOptions());
                        ms.Position = 0;
                        RasterImage clone = (RasterImage)Image.Load(ms);
                        frames.Add(clone);
                    }
                }
            }

            Image[] images = new Image[frames.Count];
            for (int i = 0; i < frames.Count; i++)
            {
                images[i] = frames[i];
            }

            using (Image result = Image.Create(images, true))
            {
                GifOptions gifOptions = new GifOptions();
                result.Save(outputPath, gifOptions);
            }

            foreach (var frame in frames)
            {
                frame.Dispose();
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
 * 1. When you need to display a multi‑page DjVu document as an animated GIF on a website.
 * 2. When you want to preserve the visual fidelity of scanned DjVu pages while reducing file size for email attachments.
 * 3. When you have to batch‑process DjVu files and generate GIF previews for a document management system.
 * 4. When you need to convert DjVu pages to a format supported by legacy applications that only read GIF images.
 * 5. When you are creating a slideshow of DjVu pages and require dithering to improve color representation in the GIF output.
 */
