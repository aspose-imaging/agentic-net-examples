using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        string inputDirectory = "InputImages";
        string outputPath = "Output/output.kml";

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
        var imageFiles = jpgFiles.Concat(jpegFiles).ToArray();

        using (var writer = new StreamWriter(outputPath))
        {
            writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2"">");
            writer.WriteLine("<Document>");

            foreach (var filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var exif = image.ExifData;
                    if (exif == null)
                        continue;

                    var latitude = exif.GPSLatitude;
                    var longitude = exif.GPSLongitude;
                    if (latitude == null || longitude == null)
                        continue;

                    string name = Path.GetFileNameWithoutExtension(filePath);
                    writer.WriteLine("<Placemark>");
                    writer.WriteLine($"<name>{name}</name>");
                    writer.WriteLine("<Point>");
                    writer.WriteLine($"<coordinates>{longitude},{latitude},0</coordinates>");
                    writer.WriteLine("</Point>");
                    writer.WriteLine("</Placemark>");
                }
            }

            writer.WriteLine("</Document>");
            writer.WriteLine("</kml>");
        }

        Console.WriteLine($"KML file generated at {outputPath}");
    }
}