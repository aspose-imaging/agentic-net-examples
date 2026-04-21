using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.raw";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions (example: 100x100)
            int width = 100;
            int height = 100;

            // Read raw pixel data (assumed 32‑bpp ARGB, 4 bytes per pixel)
            byte[] rawBytes = File.ReadAllBytes(inputPath);

            // Convert byte array to int[] pixel array
            int[] pixels = new int[width * height];
            int bytesToCopy = Math.Min(rawBytes.Length, pixels.Length * 4);
            Buffer.BlockCopy(rawBytes, 0, pixels, 0, bytesToCopy);

            // Set BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Compression = BitmapCompression.Rgb,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the image from the pixel array
            using (Image image = Image.Create(bmpOptions, width, height, pixels))
            {
                // Save the image to the specified BMP file
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}