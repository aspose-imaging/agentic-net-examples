using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths
        string inputPath = "Input/sample.djvu";
        string outputDir = "Output";
        string animatedGifPath = Path.Combine(outputDir, "animated.gif");

        // Validate input file
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load DjVu document
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvu = new DjvuImage(stream))
        {
            // Export pages 8‑10 (zero‑based indexes 7,8,9) as individual GIF files
            int[] pageIndexes = new int[] { 7, 8, 9 };
            string[] tempGifPaths = new string[pageIndexes.Length];

            for (int i = 0; i < pageIndexes.Length; i++)
            {
                string tempPath = Path.Combine(outputDir, $"page_{pageIndexes[i] + 1}.gif");
                tempGifPaths[i] = tempPath;

                // Ensure directory for each temp file
                Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                GifOptions pageOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(pageIndexes[i])
                };

                djvu.Save(tempPath, pageOptions);
            }

            // Create animated GIF from the exported pages with custom frame delay (e.g., 200 ms)
            const int customFrameDelay = 200; // milliseconds

            // Load first frame and initialize GifImage
            using (RasterImage firstFrame = (RasterImage)Image.Load(tempGifPaths[0]))
            using (GifImage animatedGif = new GifImage(new GifFrameBlock(firstFrame)))
            {
                animatedGif.ActiveFrame.FrameTime = customFrameDelay;

                // Add remaining frames
                for (int i = 1; i < tempGifPaths.Length; i++)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(tempGifPaths[i]))
                    {
                        animatedGif.AddPage(new GifFrameBlock(frame));
                        animatedGif.ActiveFrame.FrameTime = customFrameDelay;
                    }
                }

                // Ensure directory for animated GIF
                Directory.CreateDirectory(Path.GetDirectoryName(animatedGifPath));

                // Save the animated GIF
                animatedGif.Save(animatedGifPath);
            }
        }
    }
}