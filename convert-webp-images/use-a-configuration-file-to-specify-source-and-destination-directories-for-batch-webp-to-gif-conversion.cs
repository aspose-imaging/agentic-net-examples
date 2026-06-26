using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Configuration model matching the JSON file
    class Config
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

            // Verify configuration file exists
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Load and deserialize configuration
            string configContent = File.ReadAllText(configPath);
            Config cfg = JsonSerializer.Deserialize<Config>(configContent);

            // Basic validation of configuration values
            if (cfg == null || string.IsNullOrEmpty(cfg.SourceDir) || string.IsNullOrEmpty(cfg.DestinationDir))
            {
                Console.Error.WriteLine("Invalid configuration.");
                return;
            }

            // Process each WebP file in the source directory
            foreach (string inputPath in Directory.GetFiles(cfg.SourceDir, "*.webp"))
            {
                // Verify the input file still exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output GIF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(cfg.DestinationDir, fileNameWithoutExt + ".gif");

                // Ensure the output directory exists
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

/*
 * Real-World Use Cases:
 * 1. When a marketing team needs to convert a large collection of WebP ads into GIFs for email campaigns, a developer can use this code with a JSON config to point to the source folder of WebP files and the destination folder for the generated GIFs.
 * 2. When an e‑commerce platform stores product images in WebP to save bandwidth but must supply animated GIF previews for legacy browsers, a developer can automate the conversion by setting source and output paths in a config file.
 * 3. When a content management system runs nightly jobs to transform newly uploaded WebP graphics into GIFs for social media sharing, the batch converter reads the directories from a JSON configuration to keep the schedule flexible.
 * 4. When a game developer wants to repurpose WebP sprite sheets as GIF animations for documentation, they can define the input and output directories in a config file and let the Aspose.Imaging code process all files in one pass.
 * 5. When a digital archivist needs to migrate a folder of WebP screenshots to GIF format for compatibility with older archival tools, they can adjust the source and destination paths in the JSON config without changing the C# source code.
 */