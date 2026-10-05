// HOW-TO: Increase Gamma of GIF and Save with Lossy Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.FileFormats.Gif.GifImage gif = (Aspose.Imaging.FileFormats.Gif.GifImage)img;

                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[i];
                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)gif.ActiveFrame)
                    {
                        raster.AdjustGamma(1.2f);
                    }
                }

                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When you need to brighten a GIF animation for better visibility on bright screens while reducing its file size for web delivery.
 * 2. When you want to programmatically adjust the gamma of each frame in an animated GIF before uploading it to a mobile app to ensure consistent color appearance.
 * 3. When you are building an automated image pipeline that optimizes GIFs by enhancing contrast and applying lossy compression to meet email attachment size limits.
 * 4. When you need to preprocess legacy GIF assets by increasing their gamma and saving them with reduced bandwidth usage for faster page load times.
 * 5. When you are creating a batch tool that processes multiple GIF files, applying gamma correction and compressing them using Aspose.Imaging to store them efficiently in a cloud storage bucket.
 */
