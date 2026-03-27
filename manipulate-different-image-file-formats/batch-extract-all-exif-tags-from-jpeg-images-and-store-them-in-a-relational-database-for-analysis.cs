using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Process only JPEG files
            string ext = Path.GetExtension(inputPath).ToLowerInvariant();
            if (ext != ".jpg" && ext != ".jpeg")
                continue;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exifData = image.ExifData;
                if (exifData == null)
                    continue;

                string csvFileName = Path.GetFileNameWithoutExtension(inputPath) + "_exif.csv";
                string csvPath = Path.Combine(outputDirectory, csvFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

                using (var writer = new StreamWriter(csvPath))
                {
                    // Write header
                    writer.WriteLine("Tag,Value");

                    var properties = exifData.GetType().GetProperties()
                                            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0);

                    foreach (var prop in properties)
                    {
                        try
                        {
                            object value = prop.GetValue(exifData);
                            string valueStr = value != null ? value.ToString() : "";
                            // Escape commas in value
                            if (valueStr.Contains(","))
                                valueStr = $"\"{valueStr}\"";

                            writer.WriteLine($"{prop.Name},{valueStr}");
                        }
                        catch
                        {
                            // Ignore any property that throws
                        }
                    }
                }
            }
        }
    }
}