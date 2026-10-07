// HOW-TO: Batch Convert WebP Images to GIF Using Config File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

namespace BatchWebpToGif
{
    class Config
    {
        public string SourceDir { get; set; }
        public string DestDir { get; set; }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded path to configuration file
                string configPath = "config.json";

                if (!File.Exists(configPath))
                {
                    Console.Error.WriteLine($"File not found: {configPath}");
                    return;
                }

                string configJson = File.ReadAllText(configPath);
                Config config = JsonSerializer.Deserialize<Config>(configJson);
                if (config == null || string.IsNullOrWhiteSpace(config.SourceDir) || string.IsNullOrWhiteSpace(config.DestDir))
                {
                    Console.Error.WriteLine("Invalid configuration.");
                    return;
                }

                // Ensure source and destination directories exist
                if (!Directory.Exists(config.SourceDir))
                {
                    Console.Error.WriteLine($"Directory not found: {config.SourceDir}");
                    return;
                }

                Directory.CreateDirectory(config.DestDir);

                // Process each WebP file in the source directory
                foreach (string inputPath in Directory.GetFiles(config.SourceDir, "*.webp"))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(config.DestDir, fileNameWithoutExt + ".gif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate animated GIF previews from a folder of WebP assets without hard‑coding paths.
 * 2. When a CI/CD pipeline must automatically convert newly uploaded WebP files to GIF for legacy browsers using a configurable source and output directory.
 * 3. When a desktop tool processes a large batch of product images stored in WebP format and saves the GIF versions to a separate folder defined in a JSON config.
 * 4. When a developer wants to externalize the input and output locations for image conversion so non‑technical users can change directories without modifying code.
 * 5. When an image‑processing microservice must read configuration at runtime to convert all WebP files in a directory to GIF for downstream video‑creation workflows.
 */
