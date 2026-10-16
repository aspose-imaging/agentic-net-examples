// HOW-TO: Convert CMX to JPEG with Configurable Quality Setting in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CmxToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.cmx";
                string outputPath = "output.jpg";
                string configPath = "config.txt";

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Validate config file existence
                if (!File.Exists(configPath))
                {
                    Console.Error.WriteLine($"File not found: {configPath}");
                    return;
                }

                // Read quality setting from config file (expects a line like: Quality=85)
                int quality = 90; // default quality
                try
                {
                    foreach (var line in File.ReadAllLines(configPath))
                    {
                        var trimmed = line.Trim();
                        if (trimmed.StartsWith("Quality=", StringComparison.OrdinalIgnoreCase))
                        {
                            var valuePart = trimmed.Substring("Quality=".Length);
                            if (int.TryParse(valuePart, out int parsed))
                            {
                                quality = parsed;
                            }
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error reading config: {ex.Message}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CMX image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options with custom quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = quality
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Conversion completed: {outputPath}");
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
 * 1. When you need to generate web‑ready JPEG previews from legacy CMX drawings while allowing the compression quality to be adjusted via a configuration file.
 * 2. When an automated build pipeline must convert CMX design files to JPEG for documentation, with the JPEG quality controlled centrally without recompiling code.
 * 3. When a desktop application lets users upload CMX files and saves them as JPEG images using a user‑defined quality level stored in a settings file.
 * 4. When migrating a legacy CAD archive to a modern image format and you want to fine‑tune JPEG output size by reading the desired quality from a config file.
 * 5. When integrating Aspose.Imaging into a service that processes incoming CMX files and outputs JPEGs, and the service’s admin can change the compression quality without changing the source code.
 */
