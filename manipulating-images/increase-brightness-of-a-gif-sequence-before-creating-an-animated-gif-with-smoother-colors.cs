using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputDirectory = "C:\\temp\\frames";
        string outputPath = "C:\\temp\\output\\animated.gif";

        try
        {
            // Get all GIF frame files
            string[] frameFiles = Directory.GetFiles(inputDirectory, "*.gif");
            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine("No GIF frames found in the input directory.");
                return;
            }

            // Load the first frame, adjust brightness, and create the animated GIF
            string firstPath = frameFiles[0];
            if (!File.Exists(firstPath))
            {
                Console.Error.WriteLine($"File not found: {firstPath}");
                return;
            }

            using (Image firstImage = Image.Load(firstPath))
            {
                // Increase brightness of the first frame
                if (firstImage is GifImage firstGif)
                {
                    firstGif.AdjustBrightness(50); // brightness value in range [-255,255]
                }

                // Create a GifImage using the first frame block
                using (GifImage animatedGif = new GifImage(new GifFrameBlock((RasterImage)firstImage)))
                {
                    // Process remaining frames
                    for (int i = 1; i < frameFiles.Length; i++)
                    {
                        string path = frameFiles[i];
                        if (!File.Exists(path))
                        {
                            Console.Error.WriteLine($"File not found: {path}");
                            continue;
                        }

                        using (Image img = Image.Load(path))
                        {
                            // Increase brightness of each subsequent frame
                            if (img is GifImage gif)
                            {
                                gif.AdjustBrightness(50);
                            }

                            // Add the frame to the animated GIF
                            animatedGif.AddPage((RasterImage)img);
                        }
                    }

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the animated GIF with smoother colors
                    animatedGif.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}