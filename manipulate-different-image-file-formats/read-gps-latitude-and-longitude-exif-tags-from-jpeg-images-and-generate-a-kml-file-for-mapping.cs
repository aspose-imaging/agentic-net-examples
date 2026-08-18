// HOW-TO: Extract GPS Coordinates from JPEG and Create KML in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\photo.jpg";
            string outputPath = "Output\\photo.kml";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found.");
                    return;
                }

                double latitude = 0;
                double longitude = 0;
                bool hasLat = double.TryParse(exif.GPSLatitude?.ToString(), out latitude);
                bool hasLon = double.TryParse(exif.GPSLongitude?.ToString(), out longitude);

                if (!hasLat || !hasLon)
                {
                    Console.Error.WriteLine("GPS coordinates not available.");
                    return;
                }

                string latRef = exif.GPSLatitudeRef?.ToString();
                string lonRef = exif.GPSLongitudeRef?.ToString();

                if (!string.IsNullOrEmpty(latRef) && latRef.Equals("S", StringComparison.OrdinalIgnoreCase))
                    latitude = -latitude;
                if (!string.IsNullOrEmpty(lonRef) && lonRef.Equals("W", StringComparison.OrdinalIgnoreCase))
                    longitude = -longitude;

                string kml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                             "<kml xmlns=\"http://www.opengis.net/kml/2.2\">\n" +
                             "  <Document>\n" +
                             "    <Placemark>\n" +
                             "      <name>Photo Location</name>\n" +
                             $"      <Point><coordinates>{longitude},{latitude},0</coordinates></Point>\n" +
                             "    </Placemark>\n" +
                             "  </Document>\n" +
                             "</kml>";

                File.WriteAllText(outputPath, kml);
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
 * 1. When a travel app needs to plot user‑taken photos on a map, developers can read the JPEG EXIF GPS tags and generate a KML file for Google Earth using Aspose.Imaging in C#.
 * 2. When a real‑estate website wants to display property photos with their exact locations, the code extracts latitude/longitude from images and creates KML placemarks for integration with GIS tools.
 * 3. When a drone‑mapping solution processes aerial JPEGs, developers can automatically convert embedded GPS coordinates into KML to visualize flight paths in mapping software.
 * 4. When a wildlife research project collects camera‑trap images, the script reads the GPS metadata and produces a KML file to map animal sightings across a reserve.
 * 5. When a logistics company audits delivery proof‑of‑service photos, the program pulls GPS data from each JPEG and builds a KML report to verify routes and stops.
 */
