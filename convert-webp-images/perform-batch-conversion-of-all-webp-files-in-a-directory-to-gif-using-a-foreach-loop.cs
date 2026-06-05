using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "C:\\Images\\WebP";
            string outputDir = "C:\\Images\\Gif";

            // Process each WebP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.webp"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output GIF path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".gif");

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}