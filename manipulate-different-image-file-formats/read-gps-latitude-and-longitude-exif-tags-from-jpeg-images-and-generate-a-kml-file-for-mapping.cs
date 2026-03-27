using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input folder and output KML file paths
        string inputFolder = @"C:\Images";
        string outputPath = @"C:\Images\output.kml";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect all JPEG files in the input folder
        string[] jpegFiles = Directory.GetFiles(inputFolder, "*.jpg");

        // Prepare a list to hold KML placemark entries
        List<string> placemarks = new List<string>();

        foreach (string inputPath in jpegFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                var exif = image.ExifData;
                if (exif == null)
                    continue; // No EXIF data, skip this image

                // Retrieve GPS latitude and longitude values and their references
                var latRef = exif.GPSLatitudeRef;      // Expected "N" or "S"
                var lonRef = exif.GPSLongitudeRef;     // Expected "E" or "W"
                var latitude = exif.GPSLatitude;       // May be double or array of rationals
                var longitude = exif.GPSLongitude;     // May be double or array of rationals

                // If any GPS component is missing, skip this image
                if (latRef == null || lonRef == null || latitude == null || longitude == null)
                    continue;

                // Convert latitude and longitude to decimal degrees
                double latDecimal = ConvertToDecimalDegrees(latitude);
                double lonDecimal = ConvertToDecimalDegrees(longitude);

                // Apply reference direction (negative for South or West)
                if (latRef.Equals("S", StringComparison.OrdinalIgnoreCase))
                    latDecimal = -latDecimal;
                if (lonRef.Equals("W", StringComparison.OrdinalIgnoreCase))
                    lonDecimal = -lonDecimal;

                // Build a KML placemark for this image
                string fileName = Path.GetFileName(inputPath);
                string placemark = $@"
    <Placemark>
        <name>{EscapeXml(fileName)}</name>
        <Point>
            <coordinates>{lonDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture)},{latDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture)},0</coordinates>
        </Point>
    </Placemark>";
                placemarks.Add(placemark);
            }
        }

        // Assemble the final KML document
        StringBuilder kmlBuilder = new StringBuilder();
        kmlBuilder.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
        kmlBuilder.AppendLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2"">");
        kmlBuilder.AppendLine(@"<Document>");
        foreach (var pm in placemarks)
        {
            kmlBuilder.AppendLine(pm);
        }
        kmlBuilder.AppendLine(@"</Document>");
        kmlBuilder.AppendLine(@"</kml>");

        // Write the KML content to the output file
        File.WriteAllText(outputPath, kmlBuilder.ToString());
    }

    // Helper to convert GPS rational values (degrees, minutes, seconds) to decimal degrees
    private static double ConvertToDecimalDegrees(object gpsValue)
    {
        // Aspose.Imaging may return the GPS value as a double, or as an array of three rationals.
        // This method handles both cases.

        if (gpsValue is double d)
        {
            return d;
        }

        // Attempt to treat it as an array of three numbers (degrees, minutes, seconds)
        if (gpsValue is System.Collections.IEnumerable enumerable)
        {
            double[] parts = new double[3];
            int i = 0;
            foreach (var part in enumerable)
            {
                if (i >= 3) break;
                if (part is double pd)
                    parts[i] = pd;
                else if (part is int pi)
                    parts[i] = pi;
                else if (part is long pl)
                    parts[i] = pl;
                else
                    parts[i] = Convert.ToDouble(part);
                i++;
            }
            if (i == 3)
            {
                return parts[0] + parts[1] / 60.0 + parts[2] / 3600.0;
            }
        }

        // Fallback: return 0 if conversion fails
        return 0.0;
    }

    // Simple XML escaping for element content
    private static string EscapeXml(string text)
    {
        return System.Security.SecurityElement.Escape(text);
    }
}