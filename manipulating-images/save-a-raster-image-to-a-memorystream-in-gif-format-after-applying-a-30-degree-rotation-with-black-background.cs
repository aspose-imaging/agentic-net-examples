using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // If the image is a GIF, use the Rotate method that accepts background color
                if (image is GifImage gifImage)
                {
                    // Rotate 30 degrees clockwise, keep original dimensions, fill background with black
                    gifImage.Rotate(30f, false, Color.Black);
                }
                else
                {
                    // For non‑GIF images, fallback to a no‑op rotation (or implement alternative logic)
                    image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }

                // Prepare GIF save options
                GifOptions saveOptions = new GifOptions();

                // Save the rotated image to a MemoryStream in GIF format
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, saveOptions);
                    Console.WriteLine($"Image saved to MemoryStream, length = {memoryStream.Length} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}