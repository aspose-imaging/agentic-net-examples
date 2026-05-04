using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\input\";
            string outputDir = @"C:\output\";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all WebP files in the input directory
            foreach (string fileName in Directory.GetFiles(inputDir, "*.webp"))
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, Path.GetFileName(fileName));
                string outputPath = Path.Combine(outputDir, Path.ChangeExtension(Path.GetFileName(fileName), ".gif"));

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the directory for the output file exists
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