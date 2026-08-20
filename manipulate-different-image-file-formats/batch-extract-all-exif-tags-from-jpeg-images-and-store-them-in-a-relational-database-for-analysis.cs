// HOW-TO: Batch Extract JPEG EXIF Tags to CSV Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "InputImages";
            string outputCsvPath = "Output\\exif_data.csv";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCsvPath));

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            using (var writer = new StreamWriter(outputCsvPath))
            {
                // Write CSV header
                writer.WriteLine("FilePath,TagId,TagValue");

                foreach (string inputPath in jpegFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (JpegImage image = (JpegImage)Image.Load(inputPath))
                    {
                        var exifData = image.ExifData;
                        if (exifData == null)
                            continue;

                        // Iterate over all EXIF tags
                        foreach (var tag in exifData.Properties)
                        {
                            string tagId = tag.TagId.ToString();
                            string tagValue = tag.Value != null ? tag.Value.ToString().Replace(",", ";") : string.Empty;

                            // Write CSV line
                            writer.WriteLine($"{inputPath},{tagId},{tagValue}");
                        }
                    }
                }
            }

            Console.WriteLine($"EXIF data extraction completed. Results saved to: {outputCsvPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to catalog camera settings from thousands of product photos to import into a database for quality control.
 * 2. When building a forensic tool that audits image metadata across a folder of JPEGs to detect tampering.
 * 3. When creating a digital asset management system that indexes EXIF information for fast search and filtering.
 * 4. When generating a CSV report of location, date, and device data from travel photographs for analytics.
 * 5. When preparing image metadata for a machine‑learning pipeline that requires EXIF features stored in a relational table.
 */
