using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "sample.odg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Set PNG save options
            var pngOptions = new PngOptions();

            // Save the image to a memory stream in PNG format
            using (MemoryStream pngStream = new MemoryStream())
            {
                odgImage.Save(pngStream, pngOptions);

                // Example usage of the resulting PNG data
                byte[] pngData = pngStream.ToArray();
                Console.WriteLine($"PNG data size: {pngData.Length} bytes");
            }
        }
    }
}