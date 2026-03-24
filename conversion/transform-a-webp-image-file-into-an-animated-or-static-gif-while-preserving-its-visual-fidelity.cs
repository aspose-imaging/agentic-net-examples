using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.webp";
        string outputPath = @"C:\Images\sample.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image (static or animated)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Prepare GIF options – default options preserve all frames for animated sources
            GifOptions gifOptions = new GifOptions();

            // Save the image as GIF, keeping visual fidelity
            webPImage.Save(outputPath, gifOptions);
        }
    }
}