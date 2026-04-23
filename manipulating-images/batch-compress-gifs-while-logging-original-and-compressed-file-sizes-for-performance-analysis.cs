using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "C:\\InputGifs";
            string outputFolder = "C:\\OutputGifs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all GIF files in the input folder
            string[] gifFiles = Directory.GetFiles(inputFolder, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + "_compressed.gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure lossy compression options
                    GifOptions options = new GifOptions
                    {
                        MaxDiff = 80 // Recommended value for optimal lossy compression
                    };

                    // Save the compressed GIF
                    image.Save(outputPath, options);
                }

                // Log original and compressed file sizes
                long originalSize = new FileInfo(inputPath).Length;
                long compressedSize = new FileInfo(outputPath).Length;
                Console.WriteLine($"File: {Path.GetFileName(inputPath)} | Original: {originalSize} bytes | Compressed: {compressedSize} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}