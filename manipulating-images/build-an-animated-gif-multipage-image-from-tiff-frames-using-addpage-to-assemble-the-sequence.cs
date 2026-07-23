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

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

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

                // Create the GIF image using the first frame as the initial block
                using (GifImage gifImage = new GifImage(new GifFrameBlock(frames[0])))
                {
                    // Append remaining frames to the GIF
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a multi‑frame TIFF scan of a document into an animated GIF for web preview, they can use this code to extract each TIFF frame and assemble it with AddPage.
 * 2. When building a slideshow of satellite imagery stored as TIFF layers and wanting to deliver it as a lightweight animated GIF for mobile apps, this example shows how to load the TIFF, iterate frames, and save the GIF.
 * 3. When creating an animated product catalog where each product view is saved as a separate TIFF page, the code demonstrates how to merge those pages into a single GIF animation using Aspose.Imaging for .NET.
 * 4. When automating the generation of GIF thumbnails from multi‑page medical scans (e.g., DICOM exported as TIFF) for quick visual inspection, the snippet illustrates loading the TIFF, adding each frame with AddPage, and saving the result.
 * 5. When a developer needs to batch‑process archival TIFF files and produce animated GIFs for email newsletters, this sample provides the C# workflow to read TIFF frames, assemble them into a GIF, and handle file‑system checks.
 */