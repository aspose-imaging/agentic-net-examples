using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputKmlPath = "output.kml";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputKmlPath));

            // Verify input directory exists; create if missing
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            List<string> kmlLines = new List<string>();
            kmlLines.Add(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            kmlLines.Add(@"<kml xmlns=""http://www.opengis.net/kml/2.2"">");
            kmlLines.Add(@"<Document>");
            kmlLines.Add(@"<name>Image Locations</name>");

            foreach (string filePath in Directory.GetFiles(inputDirectory, "*.jpg"))
            {
                // Validate each file path
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var exif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
                    if (exif != null && exif.GPSLatitude != null && exif.GPSLongitude != null)
                    {
                        string latitude = exif.GPSLatitude.ToString();
                        string longitude = exif.GPSLongitude.ToString();

                        // Simple KML placemark
                        kmlLines.Add(@"<Placemark>");
                        kmlLines.Add($@"  <name>{Path.GetFileName(filePath)}</name>");
                        kmlLines.Add(@"  <Point>");
                        kmlLines.Add($@"    <coordinates>{longitude},{latitude},0</coordinates>");
                        kmlLines.Add(@"  </Point>");
                        kmlLines.Add(@"</Placemark>");
                    }
                }
            }

            kmlLines.Add(@"</Document>");
            kmlLines.Add(@"</kml>");

            File.WriteAllLines(outputKmlPath, kmlLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a real‑estate application needs to plot property photos on a Google Earth map, a developer can use Aspose.Imaging for .NET to read GPSLatitude and GPSLongitude EXIF tags from JPEG images and generate a KML file for visualizing the locations.
 * 2. When a field‑service company wants to create a route map of completed site visits, a C# program can extract the GPS coordinates stored in JPEG EXIF data and output a KML document that can be opened in GIS tools.
 * 3. When a travel blog wants to embed an interactive map showing where each travel photo was taken, the developer can read the JPEG EXIF GPS tags with Aspose.Imaging and produce a KML file for use in Google Maps or Earth.
 * 4. When a drone‑photography workflow requires batch processing of aerial JPEGs to produce a geospatial overlay, the code can read the EXIF GPSLatitude/GPSLongitude values and write them as placemarks in a KML file.
 * 5. When a wildlife‑research project needs to catalog camera‑trap images by location, a C# solution can pull the GPS metadata from each JPEG and generate a KML file that researchers can load into mapping software for analysis.
 */