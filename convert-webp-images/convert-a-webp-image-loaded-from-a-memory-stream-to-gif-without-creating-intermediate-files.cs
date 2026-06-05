using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates current directory if none)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the WebP image from a memory stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0; // reset stream position

                using (WebPImage webPImage = new WebPImage(memoryStream))
                {
                    // Save the image as GIF
                    GifOptions gifOptions = new GifOptions(); // default options
                    webPImage.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}