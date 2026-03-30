using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded input path
    private const string InputPath = @"C:\temp\sample.bmp";

    static void Main()
    {
        // Check input file existence
        if (!File.Exists(InputPath))
        {
            Console.Error.WriteLine($"File not found: {InputPath}");
            return;
        }

        // Process the image and obtain the result as a byte array
        byte[] result = ProcessImage(InputPath);

        // Example usage of the returned byte array
        Console.WriteLine($"Resulting byte array length: {result.Length}");
    }

    // Loads the image, applies a simple filter, saves to a memory stream and returns the bytes
    private static byte[] ProcessImage(string inputPath)
    {
        // Load the image from the specified file
        using (Image image = Image.Load(inputPath))
        {
            // Example filter: rotate the image 180 degrees
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Prepare save options (PNG format in this example)
            PngOptions saveOptions = new PngOptions();

            // Save the processed image to a memory stream
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, saveOptions);
                // Return the underlying byte array
                return stream.ToArray();
            }
        }
    }
}