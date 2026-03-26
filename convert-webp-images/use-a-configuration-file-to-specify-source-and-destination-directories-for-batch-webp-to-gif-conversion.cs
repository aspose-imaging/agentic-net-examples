using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point with hard‑coded paths (no args validation)
    static void Main()
    {
        // Path to the simple configuration file
        string configPath = "config.txt";

        // Ensure the configuration file exists
        if (!File.Exists(configPath))
        {
            Console.Error.WriteLine($"File not found: {configPath}");
            return;
        }

        // Read configuration lines (expected format: key=value)
        var configLines = File.ReadAllLines(configPath);
        var config = ParseConfig(configLines);

        // Retrieve source and destination directories from the config
        string sourceDir = config.ContainsKey("sourceDir") ? config["sourceDir"] : "";
        string destDir   = config.ContainsKey("destDir")   ? config["destDir"]   : "";

        // Validate source directory existence
        if (!Directory.Exists(sourceDir))
        {
            Console.Error.WriteLine($"File not found: {sourceDir}");
            return;
        }

        // Ensure destination directory exists (unconditional per rule)
        Directory.CreateDirectory(destDir);

        // Get all WebP files in the source directory
        string[] webpFiles = Directory.GetFiles(sourceDir, "*.webp");

        foreach (string inputPath in webpFiles)
        {
            // Verify each input file exists (rule enforcement)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build corresponding output path with .gif extension
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(destDir, fileName + ".gif");

            // Ensure the output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save it as GIF
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save using GIF options (default options are sufficient)
                webPImage.Save(outputPath, new GifOptions());
            }

            Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
        }
    }

    // Simple key=value parser for the configuration file
    private static Dictionary<string, string> ParseConfig(string[] lines)
    {
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                continue; // Skip empty lines and comments

            int idx = line.IndexOf('=');
            if (idx <= 0)
                continue; // Invalid line, ignore

            string key = line.Substring(0, idx).Trim();
            string value = line.Substring(idx + 1).Trim();
            dict[key] = value;
        }
        return dict;
    }
}