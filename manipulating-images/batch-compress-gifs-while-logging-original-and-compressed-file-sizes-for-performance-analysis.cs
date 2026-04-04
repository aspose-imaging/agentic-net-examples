using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Batch directory setup (must be included exactly as specified)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string filePath in files)
        {
            // Process only GIF files
            if (!filePath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                continue;

            string inputPath = filePath;

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(filePath) + "_compressed.gif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load GIF and save with compression
            using (Image image = Image.Load(inputPath))
            {
                GifOptions options = new GifOptions
                {
                    // Use lossy compression (MaxDiff > 0)
                    MaxDiff = 80
                };

                image.Save(outputPath, options);
            }

            // Log original and compressed sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Processed {Path.GetFileName(filePath)}: original {originalSize} bytes, compressed {compressedSize} bytes.");
        }
    }
}