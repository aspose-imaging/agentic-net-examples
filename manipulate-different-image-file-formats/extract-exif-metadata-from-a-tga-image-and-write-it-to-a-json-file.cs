// HOW-TO: Extract EXIF Metadata From TGA Image And Save As JSON In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Exif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output\\metadata.json";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                string json;

                if (image is JpegImage jpegImg && jpegImg.ExifData != null)
                {
                    var exif = jpegImg.ExifData;
                    json = $"{{\"Exif\":\"{exif.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"")}\"}}";
                }
                else if (image is TiffImage tiffImg && tiffImg.ExifData != null)
                {
                    var exif = tiffImg.ExifData;
                    json = $"{{\"Exif\":\"{exif.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"")}\"}}";
                }
                else
                {
                    json = "{}";
                }

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
 * 1. When you need to read camera and capture information embedded in a TGA file and export it for analysis or reporting.
 * 2. When a photo‑management application must ingest TGA images and store their EXIF tags in a searchable JSON database.
 * 3. When building a migration tool that converts legacy TGA assets into format‑agnostic metadata files for archival purposes.
 * 4. When a web service receives TGA uploads and must validate or log the embedded EXIF data without processing the image itself.
 * 5. When you want to compare EXIF data across JPEG, TIFF, and TGA images by extracting it into a common JSON structure.
 */
