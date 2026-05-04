using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options (default settings)
                BmpOptions saveOptions = new BmpOptions();

                // Save the image to a memory stream for further in‑memory processing
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, saveOptions);

                    // Example: output the size of the saved image in bytes
                    Console.WriteLine($"Image saved to memory stream, size: {memoryStream.Length} bytes");

                    // Reset stream position if further reading is required
                    memoryStream.Position = 0;

                    // Additional in‑memory processing can be performed here
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}