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
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.gif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Retrieve all frames from the TIFF
                TiffFrame[] tiffFrames = tiffImage.Frames;

                if (tiffFrames.Length == 0)
                {
                    Console.Error.WriteLine("No frames found in the TIFF image.");
                    return;
                }

                // Create the GIF image using the first frame as the initial block
                using (GifImage gifImage = new GifImage(new GifFrameBlock(tiffFrames[0])))
                {
                    // Add remaining frames to the GIF
                    for (int i = 1; i < tiffFrames.Length; i++)
                    {
                        gifImage.AddPage(tiffFrames[i]);
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
 * 1. When a developer needs to convert a multi‑page TIFF scan of a document into an animated GIF for web preview.
 * 2. When a developer wants to generate a lightweight GIF slideshow from TIFF frames captured by a medical imaging device.
 * 3. When a developer must create an animated GIF banner from a series of TIFF images produced by a satellite imaging pipeline.
 * 4. When a developer needs to programmatically assemble a GIF animation from TIFF frames extracted from a PDF for email newsletters.
 * 5. When a developer is building a C# utility that batch‑processes TIFF files and outputs animated GIFs for mobile apps.
 */