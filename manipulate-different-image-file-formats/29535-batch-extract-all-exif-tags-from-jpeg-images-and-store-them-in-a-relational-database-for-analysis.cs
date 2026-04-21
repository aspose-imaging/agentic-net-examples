using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(outputDir);

            string[] files = Directory.GetFiles(inputDir, "*.jpg", SearchOption.AllDirectories);
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    var exifData = image.ExifData;
                    if (exifData == null) continue;

                    string logPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".txt");
                    Directory.CreateDirectory(Path.GetDirectoryName(logPath));

                    using (StreamWriter writer = new StreamWriter(logPath, false))
                    {
                        foreach (var tag in exifData.Properties)
                        {
                            string name = $"Tag_{tag.TagId}";
                            string value = tag.Value?.ToString() ?? "";
                            writer.WriteLine($"{name}: {value}");
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