using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/metadata.json";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            // Use dynamic to access ExifData without compile‑time type constraints
            var exif = (image as dynamic).ExifData as Aspose.Imaging.Exif.ExifData;

            string json;

            if (exif != null)
            {
                json = "{";

                // General EXIF fields
                json += $"\"ExifVersion\":\"{exif.ExifVersion}\",";

                // Cast to JPEG EXIF for additional fields (many BMP files store JPEG‑compatible EXIF)
                var jpegExif = exif as Aspose.Imaging.Exif.JpegExifData;
                if (jpegExif != null)
                {
                    json += $"\"Make\":\"{jpegExif.Make}\",";
                    json += $"\"Model\":\"{jpegExif.Model}\",";
                    json += $"\"Orientation\":\"{jpegExif.Orientation}\",";
                }

                // Remove trailing comma if present
                if (json.EndsWith(","))
                {
                    json = json.Substring(0, json.Length - 1);
                }

                json += "}";
            }
            else
            {
                json = "{}";
            }

            File.WriteAllText(outputPath, json);
        }
    }
}