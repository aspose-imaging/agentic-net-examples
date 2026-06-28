using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output\\resolution.txt";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image and read resolution
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                double horizontalDpi = jpegImage.HorizontalResolution;
                double verticalDpi = jpegImage.VerticalResolution;

                // Create a simple record to hold the resolution values
                var record = new ResolutionRecord
                {
                    HorizontalDpi = horizontalDpi,
                    VerticalDpi = verticalDpi
                };

                // Store the record in a text file (simulating a database insert)
                string content = $"HorizontalDpi={record.HorizontalDpi}, VerticalDpi={record.VerticalDpi}";
                File.WriteAllText(outputPath, content);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Simple data holder representing a database record for image resolution
class ResolutionRecord
{
    public double HorizontalDpi { get; set; }
    public double VerticalDpi { get; set; }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract the EXIF DPI values from a JPEG file using Aspose.Imaging for .NET and store the horizontal and vertical resolution in a database record for later reporting.
 * 2. When building a digital asset management system that must read image resolution metadata from uploaded JPEG photos and persist the DPI information alongside other asset metadata.
 * 3. When creating a batch processing tool that validates that all JPEG images meet a required print resolution by reading their EXIF tags with C# and logging the results to a database.
 * 4. When integrating a photo‑upload feature into a web application that records the original image's DPI settings in a SQL table to support resolution‑based workflow decisions.
 * 5. When developing a quality‑control script that scans a folder of JPEG images, extracts their horizontal and vertical DPI using Aspose.Imaging, and writes the values to a data store for analytics.
 */