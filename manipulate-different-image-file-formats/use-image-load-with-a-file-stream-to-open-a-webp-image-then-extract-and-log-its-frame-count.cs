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
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.png";

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

            // Open a file stream for the WebP image
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the image from the stream
                using (Image image = Image.Load(stream))
                {
                    // Cast to WebPImage to access PageCount (frame count)
                    WebPImage webPImage = image as WebPImage;
                    if (webPImage != null)
                    {
                        int frameCount = webPImage.PageCount;
                        Console.WriteLine($"Frame count: {frameCount}");

                        // Optionally save the first frame to PNG
                        webPImage.Save(outputPath, new PngOptions());
                    }
                    else
                    {
                        Console.Error.WriteLine("Loaded image is not a WebP image.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}