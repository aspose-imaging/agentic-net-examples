using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.tif";
        string outputPath = @"c:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page TIFF
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            TiffFrame[] frames = tiffImage.Frames;
            if (frames.Length == 0)
            {
                Console.Error.WriteLine("No frames found in the TIFF image.");
                return;
            }

            // Create GIF using the first frame
            using (GifImage gifImage = new GifImage(new GifFrameBlock(frames[0])))
            {
                // Add remaining frames to the GIF
                for (int i = 1; i < frames.Length; i++)
                {
                    gifImage.AddPage(frames[i]);
                }

                // Save the animated GIF
                gifImage.Save(outputPath);
            }
        }
    }
}