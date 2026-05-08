using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"c:\temp\input.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load WebP image from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (Image image = Image.Load(stream))
            {
                // Cast to WebPImage to access PageCount
                WebPImage webPImage = image as WebPImage;
                if (webPImage != null)
                {
                    Console.WriteLine($"Frame count: {webPImage.PageCount}");
                }
                else
                {
                    Console.WriteLine("Loaded image is not a WebP image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}