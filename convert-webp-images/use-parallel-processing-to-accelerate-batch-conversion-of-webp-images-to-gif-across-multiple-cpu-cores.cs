using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all WebP files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.webp");

        // Process files in parallel
        files.AsParallel().ForAll(inputPath =>
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WebP image and save as GIF
            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    webpImage.Save(outputPath, gifOptions);
                }
            }
        });
    }
}