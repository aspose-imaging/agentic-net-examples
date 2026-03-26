using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

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
            GifOptions gifOptions = new GifOptions();
            // Optional: configure GIF options here if needed
            webPImage.Save(outputPath, gifOptions);
        }

        // Validate that the GIF file was created
        if (File.Exists(outputPath))
        {
            Console.WriteLine($"Successfully created GIF: {outputPath}");
        }
        else
        {
            Console.Error.WriteLine($"Failed to create GIF: {outputPath}");
        }
    }
}