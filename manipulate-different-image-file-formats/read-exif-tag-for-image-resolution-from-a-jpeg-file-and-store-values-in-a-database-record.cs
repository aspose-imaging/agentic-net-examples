// HOW-TO: Read JPEG EXIF Resolution and Save to Database in C# (Aspose.Imaging for .NET)
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
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load JPEG image and extract resolution
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                double horizontalResolution = image.HorizontalResolution;
                double verticalResolution = image.VerticalResolution;

                // Prepare data to store (simulating a database record)
                string record = $"HorizontalResolution={horizontalResolution},VerticalResolution={verticalResolution}";

                // Store the record in a text file
                File.WriteAllText(outputPath, record);
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
 * 1. When you need to import the DPI settings of uploaded JPEG photos into a SQL record for printing or layout calculations.
 * 2. When a digital asset management system must catalog image resolution metadata to filter high‑resolution assets.
 * 3. When generating thumbnails you must preserve the original horizontal and vertical resolution values for later re‑scaling.
 * 4. When auditing a batch of camera‑generated JPEGs to verify that their EXIF resolution matches required specifications.
 * 5. When synchronizing image metadata between a file system and a database to support responsive UI scaling in a C# web application.
 */
