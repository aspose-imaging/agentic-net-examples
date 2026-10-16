// HOW-TO: Batch Convert WebP Images to GIF Using Config File in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WebpToGifBatch
{
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
                var config = JsonSerializer.Deserialize<Config>(configJson);
                if (config == null || string.IsNullOrWhiteSpace(config.SourceDirectory) || string.IsNullOrWhiteSpace(config.DestinationDirectory))
                {
                    Console.Error.WriteLine("Invalid configuration.");
                    return;
                }

                string sourceDir = config.SourceDirectory;
                string destDir = config.DestinationDirectory;

                if (!Directory.Exists(sourceDir))
                {
                    Console.Error.WriteLine($"Source directory not found: {sourceDir}");
                    return;
                }

                // Ensure destination root exists
                Directory.CreateDirectory(destDir);

                string[] webpFiles = Directory.GetFiles(sourceDir, "*.webp", SearchOption.AllDirectories);
                foreach (string inputPath in webpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string relativePath = Path.GetRelativePath(sourceDir, inputPath);
                    string outputPath = Path.Combine(destDir, Path.ChangeExtension(relativePath, ".gif"));

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        // Save as GIF
                        var gifOptions = new GifOptions();
                        image.Save(outputPath, gifOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        private class Config
        {
            public string SourceDirectory { get; set; }
            public string DestinationDirectory { get; set; }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically convert a large collection of WebP assets to GIFs for compatibility with legacy browsers, they can use this code to process all files in a folder hierarchy based on a JSON config.
 * 2. When an e‑commerce platform stores product images in WebP to save bandwidth but requires GIF animations for marketing emails, the script enables batch conversion without hard‑coding paths.
 * 3. When a CI/CD pipeline must generate GIF previews from WebP screenshots during build time, the configurable source and destination directories allow seamless integration into automated workflows.
 * 4. When a mobile app development team wants to provide fallback GIFs for devices that do not support WebP, they can run this utility to create the GIF set from the existing WebP resources.
 * 5. When a content management system needs to migrate user‑uploaded WebP files to GIF format for a new feature, the program reads the directories from a config file and processes every file recursively.
 */
