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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

                // Adjust gamma for each frame to balance luminance
                float gammaValue = 1.2f; // example gamma coefficient
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set active frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    // Apply gamma correction
                    gif.AdjustGamma(gammaValue);
                }

                // Save the adjusted animated GIF
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