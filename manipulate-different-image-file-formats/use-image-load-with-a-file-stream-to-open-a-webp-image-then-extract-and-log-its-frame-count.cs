using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"c:\temp\test.webp";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open a file stream and load the WebP image using Image.Load
        using (FileStream stream = File.OpenRead(inputPath))
        using (Image image = Image.Load(stream))
        {
            // Cast to WebPImage to access the PageCount property (frame count)
            WebPImage webPImage = image as WebPImage;
            if (webPImage != null)
            {
                int frameCount = webPImage.PageCount;
                Console.WriteLine($"Frame count: {frameCount}");
            }
            else
            {
                Console.Error.WriteLine("Loaded image is not a WebP image.");
            }
        }
    }
}