// HOW-TO: Extract All Frames From WebP and Save As BMP in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input WebP file path
            string inputPath = "input.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory to store extracted BMP frames
            string outputDirectory = "extracted_frames";

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Build output BMP file path for each frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Extract the frame and save as BMP
                    using (RasterImage frameImage = (RasterImage)multipage.Pages[i])
                    {
                        frameImage.Save(outputPath, new BmpOptions());
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
 * 1. When you need to convert an animated WebP advertisement into separate BMP frames for legacy printing systems.
 * 2. When processing user‑uploaded animated WebP avatars and storing each frame as a BMP thumbnail for a Windows desktop application.
 * 3. When extracting frames from a WebP sprite sheet to edit or replace individual images in a game development pipeline.
 * 4. When migrating a collection of animated WebP assets to BMP format for compatibility with older image analysis tools.
 * 5. When generating separate BMP files from a WebP animation to perform frame‑by‑frame processing such as watermarking or OCR.
 */
