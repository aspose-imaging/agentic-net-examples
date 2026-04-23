using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Config
{
    public string SourceDirectory { get; set; }
    public string DestinationDirectory { get; set; }
}

class Program
{
    static void Main()
    {
        // Hard‑coded path to the configuration file
        string configPath = "config.json";

        // Load configuration (source and destination directories)
        Config cfg;
        try
        {
            string json = File.ReadAllText(configPath);
            cfg = JsonSerializer.Deserialize<Config>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to read configuration: {ex.Message}");
            return;
        }

        // Ensure source and destination directories are defined
        if (string.IsNullOrWhiteSpace(cfg?.SourceDirectory) || string.IsNullOrWhiteSpace(cfg?.DestinationDirectory))
        {
            Console.Error.WriteLine("Configuration must contain SourceDirectory and DestinationDirectory.");
            return;
        }

        // Enumerate all WebP files in the source directory
        string[] webpFiles = Directory.GetFiles(cfg.SourceDirectory, "*.webp", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in webpFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build the output path with .gif extension in the destination directory
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(cfg.DestinationDirectory, fileName + ".gif");

            // Ensure the output directory exists (unconditionally)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save it as GIF
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save using GIF options; Aspose.Imaging can infer format from extension
                webPImage.Save(outputPath, new GifOptions());
            }

            Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
        }
    }
}