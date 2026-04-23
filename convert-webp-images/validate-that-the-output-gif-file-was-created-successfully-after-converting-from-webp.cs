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
        string inputPath = @"c:\temp\test.webp";
        string outputPath = @"c:\temp\test.output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image and save it as GIF
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save using default GIF options
            webPImage.Save(outputPath, new GifOptions());
        }

        // Validate that the GIF file was created
        if (File.Exists(outputPath))
        {
            Console.WriteLine($"GIF created successfully: {outputPath}");
        }
        else
        {
            Console.Error.WriteLine($"Failed to create GIF: {outputPath}");
        }
    }
}