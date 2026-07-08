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

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Retrieve all frames from the TIFF
                TiffFrame[] frames = tiffImage.Frames;

                if (frames.Length == 0)
                {
                    Console.Error.WriteLine("No frames found in the TIFF image.");
                    return;
                }

                // Create the GIF image using the first frame
                using (GifImage gifImage = new GifImage(new GifFrameBlock(frames[0] as RasterImage)))
                {
                    // Add remaining frames as pages
                    for (int i = 1; i < frames.Length; i++)
                    {
                        gifImage.AddPage(frames[i] as RasterImage);
                    }

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a multi‑page scanned TIFF document into an animated GIF for quick web preview using Aspose.Imaging for .NET.
 * 2. When a developer wants to create a looping weather animation by turning sequential satellite‑image TIFF frames into a GIF with C# AddPage calls.
 * 3. When a developer builds an e‑commerce email campaign that displays a product‑photo slideshow by assembling TIFF frames into an animated GIF.
 * 4. When a developer designs a medical imaging viewer that summarizes a series of TIFF scans as an animated GIF for rapid patient assessment.
 * 5. When a developer automates the generation of animated GIFs from multi‑page TIFF reports to embed in PowerPoint presentations.
 */