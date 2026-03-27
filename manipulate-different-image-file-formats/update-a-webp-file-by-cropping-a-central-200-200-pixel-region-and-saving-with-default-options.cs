using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output_cropped.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Determine central 200x200 rectangle
            int cropWidth = 200;
            int cropHeight = 200;
            int left = (webPImage.Width - cropWidth) / 2;
            int top = (webPImage.Height - cropHeight) / 2;

            // Crop the image
            webPImage.Crop(new Rectangle(left, top, cropWidth, cropHeight));

            // Save with default WebP options
            webPImage.Save(outputPath, new WebPOptions());
        }
    }
}