using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input file path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image from the specified path
            using (Image image = Image.Load(inputPath))
            {
                // Example operation: rotate the image 180 degrees around the X axis
                image.RotateFlip(RotateFlipType.Rotate180FlipX);

                // Set up PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Save the processed image to a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // The memory stream now contains the PNG data ready for transmission
                    Console.WriteLine($"PNG image saved to memory stream, size: {memoryStream.Length} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}