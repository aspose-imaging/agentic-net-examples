using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input directory containing JPEG files
            string inputDirectory = "InputImages";

            // Log file path for EXIF data
            string logFilePath = "Output\\exif_log.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            using (var logWriter = new StreamWriter(logFilePath, append: true))
            {
                // Process each JPEG file in the input directory
                foreach (var filePath in Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly))
                {
                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    if (ext != ".jpg" && ext != ".jpeg")
                        continue;

                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Load the JPEG image
                    using (Aspose.Imaging.FileFormats.Jpeg.JpegImage image = (Aspose.Imaging.FileFormats.Jpeg.JpegImage)Aspose.Imaging.Image.Load(filePath))
                    {
                        var exifData = image.ExifData;
                        if (exifData == null)
                            continue;

                        // Cast to JpegExifData to access the collection of tags
                        var jpegExif = exifData as Aspose.Imaging.Exif.JpegExifData;
                        if (jpegExif == null)
                            continue;

                        // Write each EXIF tag to the log file
                        foreach (var tag in jpegExif.Properties)
                        {
                            string tagId = tag.TagId.ToString();
                            string tagValue = tag.Value?.ToString() ?? string.Empty;
                            logWriter.WriteLine($"Image: {filePath}, TagId: {tagId}, TagValue: {tagValue}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}