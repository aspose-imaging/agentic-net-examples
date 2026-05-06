using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Input directory containing JPEG files
            string inputDirectory = "InputImages";
            // Output CSV file to store extracted EXIF data
            string outputCsvPath = "Output\\exif_data.csv";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCsvPath));

            // Prepare CSV writer
            using (var writer = new StreamWriter(outputCsvPath, false))
            {
                // Write CSV header
                writer.WriteLine("FilePath,Make,Model,DateTimeOriginal,ExposureTime,FNumber,ISOSpeed,FocalLength,Orientation");

                // Get all JPEG files (case‑insensitive)
                string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories);
                foreach (string filePath in jpegFiles)
                {
                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    if (ext != ".jpg" && ext != ".jpeg")
                        continue;

                    // Validate input file existence
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Load JPEG image
                    using (JpegImage image = (JpegImage)Image.Load(filePath))
                    {
                        // Access EXIF data
                        var exifData = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
                        if (exifData == null)
                        {
                            // No EXIF data; write empty fields
                            writer.WriteLine($"{filePath},,,,,,,,");
                            continue;
                        }

                        // Extract selected tags (null‑safe where applicable)
                        string make = exifData.Make ?? "";
                        string model = exifData.Model ?? "";
                        string dateTimeOriginal = exifData.DateTimeOriginal ?? "";
                        string exposureTime = exifData.ExposureTime != null ? exifData.ExposureTime.ToString() : "";
                        string fNumber = exifData.FNumber != null ? exifData.FNumber.ToString() : "";
                        string isoSpeed = exifData.ISOSpeed.ToString();
                        string focalLength = exifData.FocalLength != null ? exifData.FocalLength.ToString() : "";
                        string orientation = exifData.Orientation.ToString();

                        // Write CSV line
                        writer.WriteLine($"{filePath},{EscapeCsv(make)},{EscapeCsv(model)},{EscapeCsv(dateTimeOriginal)},{EscapeCsv(exposureTime)},{EscapeCsv(fNumber)},{EscapeCsv(isoSpeed)},{EscapeCsv(focalLength)},{EscapeCsv(orientation)}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper to escape CSV fields containing commas or quotes
    private static string EscapeCsv(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }
}