// HOW-TO: Batch Convert WebP Images to GIF Using Config File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Configuration model matching the JSON file structure
    class Config
    {
        public string SourceDir { get; set; }
        public string DestinationDir { get; set; }
    }

    static void Main()
    {
        try
        {
            // Hard‑coded path to the configuration file
            string configPath = "config.json";

            // Verify the configuration file exists
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Read and deserialize the JSON configuration
            string json = File.ReadAllText(configPath);
            Config config = JsonSerializer.Deserialize<Config>(json);

            // Basic validation of the deserialized configuration
            if (config == null ||
                string.IsNullOrEmpty(config.SourceDir) ||
                string.IsNullOrEmpty(config.DestinationDir))
            {
                Console.Error.WriteLine("Invalid configuration.");
                return;
            }

            // Get all WebP files in the source directory
            string[] webpFiles = Directory.GetFiles(config.SourceDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Ensure the input file still exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output GIF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(config.DestinationDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a large collection of WebP graphics to animated GIFs for web deployment without hard‑coding paths.
 * 2. When your application must read source and target folders from a JSON settings file to allow non‑technical users to change directories.
 * 3. When you want to integrate Aspose.Imaging’s WebP and GIF support into a C# batch job that processes all files in a folder.
 * 4. When you are building a CI/CD pipeline that transforms WebP assets into GIFs as part of a build step using configurable paths.
 * 5. When you require error‑checked, directory‑aware image conversion that skips missing files and creates the output folder on the fly.
 */
