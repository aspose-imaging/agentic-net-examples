using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\pixels.bin";
        string outputPath = "Output\\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define image dimensions (must match the pixel data)
        int width = 100;
        int height = 100;
        int pixelCount = width * height;

        // Read raw pixel bytes (expected ARGB32 format)
        byte[] rawBytes = File.ReadAllBytes(inputPath);
        if (rawBytes.Length < pixelCount * 4)
        {
            Console.Error.WriteLine("Insufficient pixel data in input file.");
            return;
        }

        // Convert byte array to int[] required by Image.Create
        int[] pixels = new int[pixelCount];
        for (int i = 0; i < pixelCount; i++)
        {
            pixels[i] = BitConverter.ToInt32(rawBytes, i * 4);
        }

        // Create BMP options with output source
        using (BmpOptions bmpOptions = new BmpOptions())
        {
            bmpOptions.BitsPerPixel = 32;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image from raw pixel data
            using (Image image = Image.Create(bmpOptions, width, height, pixels))
            {
                // Save the image (output path already bound in options)
                image.Save();
            }
        }
    }
}