using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\input.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open a file stream for reading
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the image using Aspose.Imaging.Image.Load with the stream
                using (Image image = Image.Load(stream))
                {
                    // Cast to WebPImage to access PageCount (frame count)
                    if (image is WebPImage webPImage)
                    {
                        int frameCount = webPImage.PageCount;
                        Console.WriteLine($"Frame count: {frameCount}");
                    }
                    else
                    {
                        Console.Error.WriteLine("Loaded image is not a WebP image.");
                    }
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
 * 1. When building a C# web service that validates uploaded animated WebP files, a developer can use Image.Load with a FileStream to read the image and log its frame count to ensure it meets the required number of frames.
 * 2. When creating a desktop application that generates thumbnails only for the first frame of an animated WebP, a developer needs to open the file via a stream, cast to WebPImage, and retrieve the PageCount to decide if the image is animated.
 * 3. When implementing a batch processing script that skips non‑animated WebP images, a developer can load each file with Image.Load and check the WebPImage.PageCount to filter out single‑frame images.
 * 4. When developing a media‑asset pipeline that logs metadata for compliance reports, a developer can read WebP files through a stream and record the frame count as part of the image’s technical specifications.
 * 5. When troubleshooting performance issues in an image‑conversion tool, a developer may load a WebP image from a stream and output its frame count to verify that the expected number of animation frames is being processed.
 */