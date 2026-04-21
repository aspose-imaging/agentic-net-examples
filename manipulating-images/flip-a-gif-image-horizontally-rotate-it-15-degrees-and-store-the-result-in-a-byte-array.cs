using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.gif";
            string outputPath = "output/result.png";

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

                // Rotate 15 degrees, resize proportionally, transparent background
                image.Rotate(15f, true, Color.Transparent);

                // Save transformed image to file
                image.Save(outputPath, new PngOptions());

                // Also save to a memory stream to obtain a byte array
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, new PngOptions());
                    byte[] resultBytes = ms.ToArray();
                    Console.WriteLine($"Result byte array length: {resultBytes.Length}");
                    // resultBytes now contains the transformed image data
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}