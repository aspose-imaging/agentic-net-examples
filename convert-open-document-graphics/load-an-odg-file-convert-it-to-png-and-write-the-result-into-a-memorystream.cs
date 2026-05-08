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
            // Hardcoded input ODG file path
            string inputPath = @"C:\temp\sample.odg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare a memory stream to hold the PNG data
                using (MemoryStream pngStream = new MemoryStream())
                {
                    // Save the image as PNG into the memory stream
                    PngOptions pngOptions = new PngOptions();
                    odgImage.Save(pngStream, pngOptions);

                    // Optionally, display the size of the generated PNG data
                    Console.WriteLine($"PNG data length: {pngStream.Length} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}