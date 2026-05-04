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
        try
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

            // Load WebP image and save as GIF
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                webPImage.Save(outputPath, new GifOptions());
            }

            // Validate that the GIF file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"GIF file created successfully: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine($"Failed to create GIF file: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}