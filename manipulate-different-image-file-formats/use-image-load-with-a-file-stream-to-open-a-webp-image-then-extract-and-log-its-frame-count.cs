using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"c:\temp\test.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open a file stream for the WebP image
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the image from the stream
                using (Image image = Image.Load(stream))
                {
                    // Cast to WebPImage to access WebP‑specific properties
                    WebPImage webPImage = image as WebPImage;
                    if (webPImage != null)
                    {
                        // Log the number of frames (pages) in the WebP image
                        Console.WriteLine($"Frame count (PageCount): {webPImage.PageCount}");
                    }
                    else
                    {
                        Console.WriteLine("The loaded image is not a WebP image.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}