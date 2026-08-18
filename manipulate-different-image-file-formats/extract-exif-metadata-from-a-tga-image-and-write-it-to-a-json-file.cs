// HOW-TO: Extract EXIF Metadata From TGA Image To JSON In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.json";

        try
        {
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
                // Extract EXIF data
                var exifData = image.ExifData;

                // Serialize EXIF data to JSON (null handling)
                string json = JsonSerializer.Serialize(exifData, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    // Ignore cycles or unsupported members
                    IgnoreReadOnlyProperties = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                // Write JSON to output file
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
 * 1. When you need to read camera and creation details from a TGA file and store them in a JSON file for cataloging or search indexing.
 * 2. When you want to export EXIF tags from TGA images to JSON so a web service can consume the metadata for image management.
 * 3. When you are auditing a batch of TGA assets and require a machine‑readable JSON report of all embedded EXIF information.
 * 4. When you need to migrate legacy TGA metadata into a database and use JSON as the intermediate format for easy parsing in C#.
 * 5. When you are building a photo‑metadata viewer that loads TGA files and displays their EXIF data by first serializing it to JSON.
 */
