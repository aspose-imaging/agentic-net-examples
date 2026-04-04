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
        // Hardcoded input folder containing frame images and output GIF path
        string inputFolder = @"C:\temp\frames";
        string outputPath = @"C:\temp\output\animated.gif";

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Folder not found: {inputFolder}");
            return;
        }

        // Get all PNG files in the folder (adjust pattern if needed)
        string[] frameFiles = Directory.GetFiles(inputFolder, "*.png");
        if (frameFiles.Length == 0)
        {
            Console.Error.WriteLine("No frame images found.");
            return;
        }

        // Verify each frame file exists (redundant but follows the rule)
        foreach (string file in frameFiles)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }
        }

        // Prepare GIF options with text rendering hint for better caption legibility
        GifOptions gifOptions = new GifOptions();
        gifOptions.VectorRasterizationOptions = new VectorRasterizationOptions
        {
            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
        };
        // Optional: set infinite looping
        gifOptions.LoopsCount = 0;

        // Load the first frame and create the GIF image
        using (RasterImage firstImg = (RasterImage)Image.Load(frameFiles[0]))
        using (GifFrameBlock firstBlock = new GifFrameBlock(firstImg))
        using (GifImage gifImage = new GifImage(firstBlock))
        {
            // Add remaining frames
            for (int i = 1; i < frameFiles.Length; i++)
            {
                RasterImage img = (RasterImage)Image.Load(frameFiles[i]);
                GifFrameBlock block = new GifFrameBlock(img);
                gifImage.AddBlock(block);
                // Do not dispose 'block' or 'img' here; they are managed by gifImage
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the animated GIF with the configured options
            gifImage.Save(outputPath, gifOptions);
        }
    }
}