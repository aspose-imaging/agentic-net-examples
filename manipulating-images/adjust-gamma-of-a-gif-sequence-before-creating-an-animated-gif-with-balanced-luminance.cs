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
            // Hardcoded input GIF frame paths
            string frame1 = "frame1.gif";
            string frame2 = "frame2.gif";
            string frame3 = "frame3.gif";

            // Hardcoded output animated GIF path
            string outputPath = "output.gif";

            // Validate input files
            if (!File.Exists(frame1))
            {
                Console.Error.WriteLine($"File not found: {frame1}");
                return;
            }
            if (!File.Exists(frame2))
            {
                Console.Error.WriteLine($"File not found: {frame2}");
                return;
            }
            if (!File.Exists(frame3))
            {
                Console.Error.WriteLine($"File not found: {frame3}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the first frame, adjust gamma, and create the animated GIF with its first frame
            using (GifImage firstGif = (GifImage)Image.Load(frame1))
            {
                firstGif.AdjustGamma(0.8f); // Adjust gamma for balanced luminance

                using (GifImage animatedGif = new GifImage((GifFrameBlock)firstGif.ActiveFrame))
                {
                    // Load and add remaining frames
                    string[] otherFrames = { frame2, frame3 };
                    foreach (string path in otherFrames)
                    {
                        using (GifImage frameGif = (GifImage)Image.Load(path))
                        {
                            frameGif.AdjustGamma(0.8f);
                            animatedGif.AddPage((RasterImage)frameGif);
                        }
                    }

                    // Set infinite looping (0 means infinite in GIF spec)
                    animatedGif.LoopsCount = 0;

                    // Save the animated GIF with default options
                    animatedGif.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}