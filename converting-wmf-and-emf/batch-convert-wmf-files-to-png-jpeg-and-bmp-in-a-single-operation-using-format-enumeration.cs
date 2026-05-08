using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            // Define target formats
            var formatMap = new Dictionary<string, Action<Image, string>>
            {
                { "png", (img, outPath) => img.Save(outPath, new PngOptions()) },
                { "jpg", (img, outPath) => img.Save(outPath, new JpegOptions()) },
                { "bmp", (img, outPath) => img.Save(outPath, new BmpOptions()) }
            };

            foreach (var filePath in files)
            {
                // Process only WMF files
                if (!string.Equals(Path.GetExtension(filePath), ".wmf", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Validate input file existence
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Image image = Image.Load(filePath))
                {
                    foreach (var kvp in formatMap)
                    {
                        string extension = kvp.Key;
                        var saveAction = kvp.Value;

                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + "." + extension;
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists for each file
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save in the target format
                        saveAction(image, outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}