// HOW-TO: Convert CMX to JPEG with Configurable Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input, output, and config paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\output.jpg";
            string configPath = @"C:\temp\appsettings.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Default JPEG quality
            int quality = 90;

            // Read quality from a simple JSON config if it exists
            if (File.Exists(configPath))
            {
                try
                {
                    string json = File.ReadAllText(configPath);
                    using JsonDocument doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("JpegQuality", out JsonElement elem) && elem.TryGetInt32(out int q))
                    {
                        quality = q;
                    }
                }
                catch
                {
                    // Ignore parsing errors and keep default quality
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image with specific load options
            var loadOptions = new CmxLoadOptions();
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Set JPEG save options, including the custom quality
                var jpegOptions = new JpegOptions
                {
                    Quality = quality
                };

                // Save as JPEG
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
 * 1. When a legacy CorelDRAW CMX file needs to be displayed on the web, a developer can convert it to a JPEG and control the compression quality via a JSON configuration.
 * 2. When an automated image pipeline must generate thumbnails from CMX drawings with a specific visual fidelity, the code reads the desired JPEG quality from settings and saves the output accordingly.
 * 3. When a desktop application allows users to export their CMX designs to a common format, the developer can use this snippet to honor a user‑defined quality level stored in an appsettings file.
 * 4. When migrating a large archive of CMX assets to JPEG for faster loading, the program can be integrated into a batch process that reads quality parameters from a central configuration.
 * 5. When integrating Aspose.Imaging into a CI/CD build that validates image conversion, the code demonstrates how to load CMX with load options and save JPEG with a configurable quality flag.
 */
