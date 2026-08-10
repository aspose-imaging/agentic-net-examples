// HOW-TO: Extract and Save Each WebP Frame as PNG in C# with Low Memory Usage (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputDirectory = @"C:\temp\frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (parent of each output file will be created later)
            Directory.CreateDirectory(outputDirectory);

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Try to treat the image as a multipage image
                IMultipageImage multipage = webPImage as IMultipageImage;

                if (multipage != null && multipage.Pages != null && multipage.PageCount > 0)
                {
                    // Process each frame individually
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Get the current frame
                        using (Image frame = multipage.Pages[i])
                        {
                            // Build output file path for this frame
                            string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                            // Ensure the directory for this output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the frame as PNG
                            frame.Save(outputPath, new PngOptions());
                        } // frame disposed here, releasing memory
                    }
                }
                else
                {
                    // Single-frame WebP image case
                    string outputPath = Path.Combine(outputDirectory, "frame_0.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    webPImage.Save(outputPath, new PngOptions());
                }
            } // webPImage disposed here
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert an animated WebP file into separate PNG images without loading the entire animation into memory.
 * 2. When processing large WebP animations on a server with limited RAM, extracting each frame individually to avoid out‑of‑memory errors.
 * 3. When creating thumbnails or individual assets from each frame of a WebP animation for use in a web gallery or mobile app.
 * 4. When automating a pipeline that extracts frames from user‑uploaded WebP stickers to store them as PNGs in a database.
 * 5. When performing batch conversion of multiple WebP files to PNG while ensuring each frame is disposed promptly to keep the application responsive.
 */
