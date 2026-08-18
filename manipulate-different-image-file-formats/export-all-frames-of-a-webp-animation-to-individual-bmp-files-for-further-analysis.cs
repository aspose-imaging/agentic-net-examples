// HOW-TO: Export All Frames From Animated WebP to BMP Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WebP animation file
            string inputPath = "input.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory to store extracted BMP frames
            string outputDirectory = "frames";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the WebP animation
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Try to treat the image as a multipage image
                IMultipageImage multipage = webPImage as IMultipageImage;

                if (multipage != null && multipage.PageCount > 0)
                {
                    // Iterate through each frame/page
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Each page implements IFrame; cast to RasterImage for saving
                        RasterImage frame = (RasterImage)multipage.Pages[i];

                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                        // Ensure the directory for this frame exists (unconditional call as required)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP
                        frame.Save(outputPath, new BmpOptions());
                    }
                }
                else
                {
                    // Single-frame WebP (non-animated)
                    RasterImage raster = (RasterImage)webPImage;
                    string outputPath = Path.Combine(outputDirectory, "frame_0.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract each frame of an animated WebP for pixel‑level analysis or computer‑vision preprocessing, they can use this code to save the frames as BMP images.
 * 2. When converting animated WebP assets into a series of lossless BMP files for compatibility with legacy Windows applications that only accept BMP, this snippet provides an automated solution.
 * 3. When preparing frame‑by‑frame screenshots from a WebP animation for documentation or UI testing, the code quickly generates individual BMP files for each frame.
 * 4. When performing batch processing of WebP animations to generate thumbnails or watermarks on each frame, extracting the frames as BMP allows easy manipulation with standard .NET imaging libraries.
 * 5. When archiving animated WebP content in a format that preserves exact pixel data for forensic or quality‑control audits, developers can use this approach to export every frame to BMP.
 */
