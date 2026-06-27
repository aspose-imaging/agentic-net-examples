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
            string inputPath = "input.jpg";
            string outputPath = "output.kml";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found.");
                    return;
                }

                var latitude = exif.GPSLatitude;
                var longitude = exif.GPSLongitude;

                if (latitude == null || longitude == null)
                {
                    Console.Error.WriteLine("GPS latitude or longitude not found in EXIF data.");
                    return;
                }

                string kmlContent = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                    $"<kml xmlns=\"http://www.opengis.net/kml/2.2\">\n" +
                                    $"  <Document>\n" +
                                    $"    <Placemark>\n" +
                                    $"      <name>{Path.GetFileNameWithoutExtension(inputPath)}</name>\n" +
                                    $"      <Point><coordinates>{longitude},{latitude},0</coordinates></Point>\n" +
                                    $"    </Placemark>\n" +
                                    $"  </Document>\n" +
                                    $"</kml>";

                File.WriteAllText(outputPath, kmlContent);
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
 * 1. When a travel‑blogger wants to automatically plot photos taken on a road trip onto Google Earth, they can use this C# code with Aspose.Imaging to read JPEG EXIF GPS tags and create a KML file for mapping.
 * 2. When a real‑estate company needs to generate a location‑aware property catalog, developers can extract latitude and longitude from property‑photo JPEGs and produce KML placemarks for each image.
 * 3. When a wildlife researcher collects camera‑trap images and wants to visualize animal sightings on a map, the code reads the GPS EXIF data from each JPEG and writes a KML file that can be opened in GIS tools.
 * 4. When a municipal GIS team receives field‑survey photos and must convert the embedded GPS coordinates into a standard KML layer, this Aspose.Imaging‑based C# snippet automates the extraction and KML generation.
 * 5. When an e‑commerce platform wants to display where product photos were taken, developers can use the example to pull GPSLatitude and GPSLongitude from JPEG EXIF metadata and generate a KML file for interactive map integration.
 */