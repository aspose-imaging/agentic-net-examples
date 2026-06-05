using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output.gif";

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

            // Load the GIF image
            using (GifImage image = (GifImage)Image.Load(inputPath))
            {
                // Flip horizontally
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Rotate 15 degrees clockwise, resize proportionally, transparent background
                image.Rotate(15f, true, Color.Transparent);

                // Save to file
                image.Save(outputPath, new GifOptions());

                // Also save to a memory stream to obtain a byte array
                byte[] resultBytes;
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, new GifOptions());
                    resultBytes = ms.ToArray();
                }

                // Example usage of the byte array (here we just output its length)
                Console.WriteLine($"Result byte array length: {resultBytes.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}