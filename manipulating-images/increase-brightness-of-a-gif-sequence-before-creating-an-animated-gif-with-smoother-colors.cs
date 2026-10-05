// HOW-TO: Increase Brightness of GIF Frames and Create Animated GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputPath = "output/animated.gif";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] inputFiles = Directory.GetFiles(inputFolder, "*.gif");
            if (inputFiles.Length == 0)
            {
                Console.Error.WriteLine("No GIF files found in the input folder.");
                return;
            }

            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            // Determine canvas size from the first frame of the first GIF
            int canvasWidth;
            int canvasHeight;
            using (GifImage firstGif = (GifImage)Image.Load(inputFiles[0]))
            {
                GifFrameBlock firstFrame = (GifFrameBlock)firstGif.Pages[0];
                canvasWidth = firstFrame.Width;
                canvasHeight = firstFrame.Height;
            }

            GifOptions gifOptions = new GifOptions();

            using (GifImage outputGif = (GifImage)Image.Create(gifOptions, canvasWidth, canvasHeight))
            {
                foreach (string file in inputFiles)
                {
                    using (GifImage srcGif = (GifImage)Image.Load(file))
                    {
                        foreach (var page in srcGif.Pages)
                        {
                            GifFrameBlock frame = (GifFrameBlock)page;
                            RasterImage raster = (RasterImage)frame;
                            raster.AdjustBrightness(50); // increase brightness
                            outputGif.AddPage(frame);
                        }
                    }
                }

                outputGif.Save(outputPath, gifOptions);
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
 * 1. When you need to brighten a series of low‑contrast GIF images before merging them into a smooth animated GIF for web banners.
 * 2. When you want to programmatically adjust the brightness of each frame in multiple GIF files to improve visibility on mobile devices using Aspose.Imaging for .NET.
 * 3. When you are building a C# application that creates an animated GIF from separate GIF clips and requires consistent lighting across all frames.
 * 4. When you need to preprocess GIF frames by increasing their brightness to match a brand’s color palette before generating a looping animation.
 * 5. When you automate the conversion of a folder of GIF sequences into a single animated GIF with enhanced brightness for presentation slides.
 */
