using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

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
                // Save as GIF
                using (GifOptions gifOptions = new GifOptions())
                {
                    apngImage.Save(outputPath, gifOptions);
                }
            }

            // Verify the resulting GIF
            using (Image gifImage = Image.Load(outputPath))
            {
                if (gifImage is GifImage gif)
                {
                    if (gif.PageCount > 1)
                    {
                        Console.WriteLine("Verification passed: GIF contains multiple frames.");
                    }
                    else
                    {
                        Console.WriteLine("Verification warning: GIF does not contain multiple frames.");
                    }
                }
                else
                {
                    Console.WriteLine("Verification warning: Loaded image is not a GIF.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}