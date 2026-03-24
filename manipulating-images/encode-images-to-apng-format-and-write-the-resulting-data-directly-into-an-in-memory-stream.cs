using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"C:\Images\source.webp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image (can be single‑frame or multi‑frame)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Configure APNG options (default frame time = 200 ms, infinite looping)
            ApngOptions apngOptions = new ApngOptions
            {
                DefaultFrameTime = 200 // milliseconds
                // NumPlays defaults to 0 (infinite)
            };

            // Create an in‑memory stream to hold the APNG data
            using (MemoryStream apngStream = new MemoryStream())
            {
                // Save the image as APNG into the memory stream
                sourceImage.Save(apngStream, apngOptions);

                // Optionally, reset the stream position for further processing
                apngStream.Position = 0;

                // Example: output the size of the generated APNG data
                Console.WriteLine($"APNG data size: {apngStream.Length} bytes");
            }
        }
    }
}