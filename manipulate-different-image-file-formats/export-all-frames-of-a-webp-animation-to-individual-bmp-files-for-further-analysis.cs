using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/animation.webp";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the animated WebP image
        using (WebPImage webP = new WebPImage(inputPath))
        {
            int frameCount = webP.PageCount;

            for (int i = 0; i < frameCount; i++)
            {
                // Build output file path for each frame
                string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure BMP options to export only the current frame
                BmpOptions bmpOptions = new BmpOptions
                {
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                };

                // Save the current frame as BMP
                webP.Save(outputPath, bmpOptions);
            }
        }
    }
}