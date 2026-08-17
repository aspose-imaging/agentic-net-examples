// HOW-TO: Create Animated GIF From Multi‑Page TIFF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.gif";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame[] frames = tiffImage.Frames;
                if (frames == null || frames.Length == 0)
                {
                    Console.Error.WriteLine("No frames found in the TIFF image.");
                    return;
                }

                // Create the GIF image using the first frame
                using (GifImage gifImage = new GifImage(new GifFrameBlock((RasterImage)frames[0])))
                {
                    // Append remaining frames as pages
                    for (int i = 1; i < frames.Length; i++)
                    {
                        gifImage.AddPage((RasterImage)frames[i]);
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
 * 1. When you need to turn a multi‑page scanned document (TIFF) into a lightweight animated GIF for quick preview in a web application.
 * 2. When you want to generate an animated product showcase by combining each frame of a TIFF sprite sheet into a looping GIF using C#.
 * 3. When you have a series of medical imaging slices stored as TIFF frames and must deliver them as an animated GIF for remote diagnosis.
 * 4. When you are building an email newsletter and need to compress a multi‑frame TIFF into an animated GIF that most email clients can display.
 * 5. When you automate a reporting pipeline that extracts chart pages from a TIFF report and assembles them into an animated GIF for dashboard visualisation.
 */
