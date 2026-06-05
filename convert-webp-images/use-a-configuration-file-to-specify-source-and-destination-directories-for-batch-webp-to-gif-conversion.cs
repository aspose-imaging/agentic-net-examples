using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Configuration model
    private class Config
    {
        public string SourceDir { get; set; }
        public string DestinationDir { get; set; }
    }

    static void Main()
    {
        try
        {
            // Hardcoded configuration file path
            string configPath = "config.json";

            // Load configuration
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            string configJson = File.ReadAllText(configPath);
            Config config = JsonSerializer.Deserialize<Config>(configJson);

            // Ensure source and destination directories are defined
            if (config == null || string.IsNullOrEmpty(config.SourceDir) || string.IsNullOrEmpty(config.DestinationDir))
            {
                Console.Error.WriteLine("Invalid configuration.");
                return;
            }

            // Get all WebP files in the source directory
            string[] webpFiles = Directory.GetFiles(config.SourceDir, "*.webp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists (redundant because GetFiles returns existing files, but follows rule)
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output path with .gif extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(config.DestinationDir, fileName + ".gif");

                // Ensure destination directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}