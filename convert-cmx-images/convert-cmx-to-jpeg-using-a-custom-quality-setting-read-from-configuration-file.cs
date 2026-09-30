// HOW-TO: Convert CMX to JPEG with Configurable Quality Setting in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.cmx";
            string outputPath = "output\\output.jpg";
            string configPath = "config.json";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Default quality
            int quality = 90;

            // Read quality from configuration file if present
            if (File.Exists(configPath))
            {
                try
                {
                    string json = File.ReadAllText(configPath);
                    using JsonDocument doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("Quality", out JsonElement qElem) &&
                        qElem.TryGetInt32(out int qValue))
                    {
                        quality = qValue;
                    }
                }
                catch
                {
                    // Ignore any parsing errors and keep default quality
                }
            }

            // Load CMX and save as JPEG with specified quality
            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = quality
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to batch‑convert CorelDRAW CMX drawings to JPEG for web preview while controlling compression quality from a config file.
 * 2. When an application must read a user‑defined JPEG quality value from JSON and apply it during image export.
 * 3. When you want to ensure the output folder exists before saving converted images to avoid runtime errors.
 * 4. When you need to gracefully handle missing or malformed configuration files and fall back to a default JPEG quality.
 * 5. When you must verify the source CMX file exists and report an error early to prevent processing failures.
 */
