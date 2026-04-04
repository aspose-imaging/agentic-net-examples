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
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the source GIF
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Process each frame to deskew
            for (int i = 0; i < gif.PageCount; i++)
            {
                // Set the active frame
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                // Cache data for performance
                if (!gif.IsCached)
                {
                    gif.CacheData();
                }

                // Determine skew angle
                float skewAngle = gif.GetSkewAngle();

                // Rotate to correct the skew if needed
                if (Math.Abs(skewAngle) > 0.01f)
                {
                    // Rotate opposite to the skew angle, resize proportionally, fill background with white
                    gif.Rotate(-skewAngle, true, Color.White);
                }
            }

            // Save the corrected animated GIF
            gif.Save(outputPath, new GifOptions());
        }
    }
}