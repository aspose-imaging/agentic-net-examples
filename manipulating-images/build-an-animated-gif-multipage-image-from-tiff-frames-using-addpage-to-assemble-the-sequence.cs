using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"c:\temp\input.tif";
        string outputPath = @"c:\temp\output.gif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Retrieve all frames
                TiffFrame[] frames = tiffImage.Frames;

                if (frames.Length == 0)
                {
                    Console.Error.WriteLine("No frames found in the TIFF image.");
                    return;
                }

                // Create the GIF image using the first frame
                using (GifImage gifImage = new GifImage(new GifFrameBlock(frames[0])))
                {
                    // Add remaining frames as pages
                    for (int i = 1; i < frames.Length; i++)
                    {
                        gifImage.AddPage(frames[i]);
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the animated GIF
                    gifImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}