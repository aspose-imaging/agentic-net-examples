using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input WebP file path
        string inputPath = "input.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output directory for extracted frames
        string outputDir = "output_frames";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            int frameCount = webPImage.PageCount;

            for (int i = 0; i < frameCount; i++)
            {
                // Build output BMP file path for each frame
                string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Extract the frame as a RasterImage
                RasterImage frame = (RasterImage)webPImage.Pages[i];

                // Save the frame as BMP
                frame.Save(outputPath, new BmpOptions());
            }
        }
    }
}