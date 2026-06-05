using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image
            using (TgaImage image = (TgaImage)Image.Load(inputPath))
            {
                // Extract EXIF metadata
                var exifData = image.ExifData;

                // Serialize EXIF data to JSON
                string json = JsonSerializer.Serialize(exifData, new JsonSerializerOptions { WriteIndented = true });

                // Write JSON to file
                File.WriteAllText(outputPath, json);
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
 * 1. When a game developer needs to catalog camera settings stored in TGA textures for a Unity asset pipeline, they can extract the EXIF metadata and save it as JSON for easy indexing.
 * 2. When a digital forensics analyst wants to preserve provenance information from a TGA screenshot, they can use this code to pull EXIF tags and export them to a JSON report.
 * 3. When a web service processes uploaded TGA files and must provide metadata to front‑end clients, extracting EXIF data and serializing it to JSON enables seamless API responses.
 * 4. When a batch‑processing tool converts legacy TGA artwork to modern formats, extracting the EXIF metadata to JSON helps retain original capture details for documentation.
 * 5. When a content management system stores TGA assets and needs searchable metadata, this code extracts the EXIF information and writes it to a JSON file that can be indexed by search engines.
 */