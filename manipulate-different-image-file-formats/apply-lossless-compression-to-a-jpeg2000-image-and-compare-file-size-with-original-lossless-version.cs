using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.jp2";
            string outputPath = "Output\\sample_lossless.jp2";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the original JPEG2000 image
            using (Jpeg2000Image image = new Jpeg2000Image(inputPath))
            {
                // Set up lossless compression options (default is lossless)
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false // explicit lossless mode
                };

                // Save the image with lossless compression
                image.Save(outputPath, options);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}