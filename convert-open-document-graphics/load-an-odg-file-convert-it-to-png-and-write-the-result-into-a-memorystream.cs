using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.odg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare a memory stream for the PNG output
            using (MemoryStream pngStream = new MemoryStream())
            {
                // PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG into the memory stream
                odgImage.Save(pngStream, pngOptions);

                // Reset stream position if further processing is needed
                pngStream.Position = 0;

                // Example: output the size of the generated PNG data
                Console.WriteLine($"PNG data length: {pngStream.Length} bytes");
            }
        }
    }
}