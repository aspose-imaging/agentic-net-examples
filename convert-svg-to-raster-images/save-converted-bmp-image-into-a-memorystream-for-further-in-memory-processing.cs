using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input path
        string inputPath = @"C:\temp\sample.bmp";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Example conversion: rotate the image 180 degrees
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Prepare BMP save options (default settings are fine for this example)
            BmpOptions saveOptions = new BmpOptions();

            // Save the processed image into a memory stream for further in‑memory work
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, saveOptions);
                Console.WriteLine($"Image saved to memory stream, size = {memoryStream.Length} bytes");
                // Additional in‑memory processing can be performed here using memoryStream
            }
        }
    }
}