using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Config
{
    public string SourceDir { get; set; }
    public string DestinationDir { get; set; }
}

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded path to the configuration file
            string configPath = "config.json";

            // Load and deserialize configuration
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
            string[] webpFiles = Directory.GetFiles(config.SourceDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output GIF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(config.DestinationDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as GIF
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