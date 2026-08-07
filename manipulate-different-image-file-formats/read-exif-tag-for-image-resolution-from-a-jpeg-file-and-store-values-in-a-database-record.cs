// HOW-TO: Read JPEG EXIF Resolution and Save to Database in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/resolution.txt";

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
                // Read resolution from EXIF (or image properties)
                double horizontalResolution = image.HorizontalResolution;
                double verticalResolution = image.VerticalResolution;

                // Simulate storing in a database by writing to a text file
                string record = $"HorizontalResolution={horizontalResolution},VerticalResolution={verticalResolution}";
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
 * 1. When you need to extract the DPI settings of uploaded JPEG photos and store them in a product catalog database.
 * 2. When a web application must validate image resolution before allowing users to publish high‑resolution graphics.
 * 3. When a digital asset management system records the horizontal and vertical resolution of JPEG files for search and filtering.
 * 4. When a batch process imports scanned documents and logs their DPI values to ensure compliance with printing standards.
 * 5. When an e‑commerce platform saves image metadata such as resolution to optimize image rendering on different devices.
 */
