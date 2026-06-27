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
            // Hardcoded input and output paths
            string inputDirectory = "InputImages";
            string outputSqlPath = "Output\\exif_data.sql";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputSqlPath));

            using (var writer = new StreamWriter(outputSqlPath, false))
            {
                // Write basic SQL header
                writer.WriteLine("CREATE TABLE IF NOT EXISTS ExifData (FileName TEXT, ExifHex TEXT);");

                // Process each JPEG file in the input directory
                foreach (string filePath in Directory.GetFiles(inputDirectory, "*.jpg"))
                {
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
                        var jpegExif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
                        if (jpegExif != null)
                        {
                            // Serialize EXIF data to byte array and convert to hex string
                            byte[] exifBytes = jpegExif.SerializeExifData();
                            string hex = BitConverter.ToString(exifBytes).Replace("-", "");

                            // Prepare SQL INSERT statement
                            string fileName = Path.GetFileName(filePath).Replace("'", "''");
                            string insert = $"INSERT INTO ExifData (FileName, ExifHex) VALUES ('{fileName}', '{hex}');";
                            writer.WriteLine(insert);
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

/*
 * Real-World Use Cases:
 * 1. When a photography studio needs to catalog thousands of client JPEG files and store each image’s EXIF metadata in a SQL table for quick search and reporting.
 * 2. When a digital asset management system must import a batch of product photos, extract camera settings and GPS coordinates, and save them as hex strings in a relational database for analytics.
 * 3. When a compliance audit requires preserving original EXIF information from exported JPEGs, so the code reads each file, serializes the EXIF data, and inserts it into an audit‑ready database.
 * 4. When a machine‑learning pipeline wants to enrich training data with image metadata, using C# to pull EXIF tags from a folder of JPEGs and store them in a database for feature engineering.
 * 5. When a web application needs to generate a searchable inventory of uploaded JPEG images, extracting their EXIF tags and persisting the data in a relational database for later filtering by camera model or exposure settings.
 */