// HOW-TO: How to Deskew an Animated GIF and Save Corrected Frames in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.gif";
            string outputPath = "output\\deskewed.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Process each frame to deskew
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set the active frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    // Determine skew angle
                    double skewAngle = gif.GetSkewAngle();

                    // Rotate to correct the skew (if any)
                    if (Math.Abs(skewAngle) > 0.01)
                    {
                        gif.Rotate((float)skewAngle, true, Color.White);
                    }
                }

                // Save the corrected animated GIF
                gif.Save(outputPath);
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
 * 1. When you receive scanned animated GIFs that are tilted and need to be straightened before displaying on a website.
 * 2. When an automated pipeline must correct the orientation of each frame in a GIF to improve OCR accuracy.
 * 3. When you want to rotate and deskew every frame of a GIF captured from a camera to create a smooth, level animation.
 * 4. When a mobile app processes user‑uploaded GIF stickers that may be skewed and requires a corrected animated output.
 * 5. When a batch job cleans up legacy GIF assets by removing skew and saving the result as a new animated GIF file.
 */
