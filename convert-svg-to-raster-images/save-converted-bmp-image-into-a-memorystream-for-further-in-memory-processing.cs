using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input path
        string inputPath = @"C:\temp\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // If the image is a BMP, perform a sample conversion (binarization)
            if (image is BmpImage bmpImage)
            {
                bmpImage.BinarizeOtsu();
            }

            // Define save options (using BMP options as an example)
            var saveOptions = new BmpOptions
            {
                BitsPerPixel = 24 // default 24‑bpp
            };

            // Save the entire image to a memory stream for further processing
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, saveOptions);

                // Example: output the size of the saved image in bytes
                Console.WriteLine($"Image saved to memory stream, size: {memoryStream.Length} bytes");

                // Further in‑memory processing can be performed here using memoryStream
            }
        }
    }
}