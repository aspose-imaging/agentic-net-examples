using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input file path (relative)
        string inputPath = "Input/sample.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions
            {
                // Example option settings (optional)
                // Compression level 6 (mid-range)
                // PngCompressionLevel = PngCompressionLevel.ZipLevel6
            };

            // Obtain the HTTP response stream.
            // In a real web scenario this would be the response output stream.
            // Here we use the standard output stream for demonstration.
            using (Stream responseStream = Console.OpenStandardOutput())
            {
                // Write the PNG image directly to the response stream
                image.Save(responseStream, pngOptions);
            }
        }
    }
}