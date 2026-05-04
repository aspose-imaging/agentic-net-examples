using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\inputWebP";
        string outputDir = @"C:\outputGif";

        try
        {
            // Get all WebP files recursively
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp", SearchOption.AllDirectories);

            // Process files in parallel
            Parallel.ForEach(webpFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path preserving relative folder structure
                string relativePath = Path.GetRelativePath(inputDir, inputPath);
                string outputPath = Path.Combine(outputDir, Path.ChangeExtension(relativePath, ".gif"));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}