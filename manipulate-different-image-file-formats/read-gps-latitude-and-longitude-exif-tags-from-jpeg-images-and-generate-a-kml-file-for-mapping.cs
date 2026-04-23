using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\photo.jpg";
            string outputPath = "C:\\Output\\photo.kml";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                JpegExifData exif = image.ExifData as JpegExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found in the image.");
                    return;
                }

                // Retrieve GPS tags
                var latRef = exif.GPSLatitudeRef;
                var lonRef = exif.GPSLongitudeRef;
                var latValues = exif.GPSLatitude;   // Expected to be an array of three rational numbers (degrees, minutes, seconds)
                var lonValues = exif.GPSLongitude; // Same as above

                if (latValues == null || lonValues == null || latRef == null || lonRef == null)
                {
                    Console.Error.WriteLine("GPS information is missing in the EXIF data.");
                    return;
                }

                // Convert rational GPS values to decimal degrees
                double ConvertToDecimal(object[] rationalValues, string reference)
                {
                    // Each element is expected to be a Rational (numerator/denominator)
                    // Aspose.Imaging represents rational numbers as double for simplicity
                    // If the type is not double, attempt to parse
                    double degrees = 0, minutes = 0, seconds = 0;

                    if (rationalValues.Length >= 1 && double.TryParse(rationalValues[0].ToString(), out double d))
                        degrees = d;
                    if (rationalValues.Length >= 2 && double.TryParse(rationalValues[1].ToString(), out double m))
                        minutes = m;
                    if (rationalValues.Length >= 3 && double.TryParse(rationalValues[2].ToString(), out double s))
                        seconds = s;

                    double decimalDeg = Math.Abs(degrees) + minutes / 60.0 + seconds / 3600.0;
                    // Apply sign based on reference (N/S, E/W)
                    if (reference.Equals("S", StringComparison.OrdinalIgnoreCase) ||
                        reference.Equals("W", StringComparison.OrdinalIgnoreCase))
                    {
                        decimalDeg = -decimalDeg;
                    }
                    return decimalDeg;
                }

                double latitude = ConvertToDecimal((object[])latValues, latRef);
                double longitude = ConvertToDecimal((object[])lonValues, lonRef);

                // Build KML content
                string kml = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                             $"<kml xmlns=\"http://www.opengis.net/kml/2.2\">\n" +
                             $"  <Document>\n" +
                             $"    <Placemark>\n" +
                             $"      <name>{Path.GetFileNameWithoutExtension(inputPath)}</name>\n" +
                             $"      <Point><coordinates>{longitude},{latitude},0</coordinates></Point>\n" +
                             $"    </Placemark>\n" +
                             $"  </Document>\n" +
                             $"</kml>";

                // Write KML file
                File.WriteAllText(outputPath, kml);
                Console.WriteLine($"KML file created at: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}