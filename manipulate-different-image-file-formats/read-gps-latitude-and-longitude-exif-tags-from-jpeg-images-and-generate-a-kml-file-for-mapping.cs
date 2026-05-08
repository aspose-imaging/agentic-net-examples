using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.kml";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    var latitude = exif.GPSLatitude;
                    var longitude = exif.GPSLongitude;

                    string latitudeStr = latitude != null ? latitude.ToString() : "";
                    string longitudeStr = longitude != null ? longitude.ToString() : "";

                    string kmlContent = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                        $"<kml xmlns=\"http://www.opengis.net/kml/2.2\">\n" +
                                        $"  <Document>\n" +
                                        $"    <Placemark>\n" +
                                        $"      <name>{Path.GetFileNameWithoutExtension(inputPath)}</name>\n" +
                                        $"      <Point>\n" +
                                        $"        <coordinates>{longitudeStr},{latitudeStr},0</coordinates>\n" +
                                        $"      </Point>\n" +
                                        $"    </Placemark>\n" +
                                        $"  </Document>\n" +
                                        $"</kml>";

                    File.WriteAllText(outputPath, kmlContent);
                }
                else
                {
                    Console.WriteLine("No EXIF data found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}