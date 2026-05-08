using System;
using System.IO;
using System.Collections.Generic;
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
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int frameDelay = 200; // milliseconds

            List<RasterImage> frames = new List<RasterImage>();

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int[] pageIndexes = new int[] { 7, 8, 9 }; // pages 8‑10 (zero‑based)

                foreach (int idx in pageIndexes)
                {
                    Image pageImg = djvu.Pages[idx];
                    RasterImage raster = (RasterImage)pageImg;
                    frames.Add(raster);
                }

                if (frames.Count > 0)
                {
                    using (var gif = new GifImage(new GifFrameBlock(frames[0])))
                    {
                        gif.ActiveFrame.FrameTime = frameDelay;

                        for (int i = 1; i < frames.Count; i++)
                        {
                            gif.AddPage(frames[i]);
                            gif.ActiveFrame.FrameTime = frameDelay;
                        }

                        gif.Save(outputPath);
                    }
                }

                foreach (var f in frames)
                {
                    f.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}