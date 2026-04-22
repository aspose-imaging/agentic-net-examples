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
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (Image apngImage = Image.Load(inputPath))
            {
                // Save as GIF using default options
                apngImage.Save(outputPath, new GifOptions());
            }

            // Verify the resulting GIF
            using (Image gifImage = Image.Load(outputPath))
            {
                if (gifImage is GifImage gif && gif.PageCount > 1)
                {
                    Console.WriteLine("GIF verification succeeded: animation contains multiple frames.");
                }
                else
                {
                    Console.WriteLine("GIF verification failed: animation does not contain multiple frames.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}