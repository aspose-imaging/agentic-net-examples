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
        string inputPath = "C:\\temp\\input.webp";
        string outputPath = "C:\\temp\\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image (supports animation)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Prepare GIF options (default preserves frames and palette)
            GifOptions gifOptions = new GifOptions();

            // Save as animated GIF
            webPImage.Save(outputPath, gifOptions);
        }
    }
}