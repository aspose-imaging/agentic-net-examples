// HOW-TO: Convert BMP to JPEG2000 and Get Output File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\source.bmp";
            string outputPath = "Output\\result.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (Jpeg2000Options options = new Jpeg2000Options())
                {
                    image.Save(outputPath, options);
                }
            }

            FileInfo info = new FileInfo(outputPath);
            Console.WriteLine($"Output file size: {info.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert legacy BMP assets to the high‑compression JPEG2000 format for web or archival storage while using Aspose.Imaging in a C# application.
 * 2. When you must programmatically generate JPEG2000 files from BMP sources to meet industry standards for medical imaging or satellite data processing.
 * 3. When you want to automate a batch job that converts BMP scans to JPEG2000 and logs the resulting file size to monitor compression efficiency.
 * 4. When you are building a .NET service that receives BMP uploads, converts them to JPEG2000, and validates the output size before saving to a database.
 * 5. When you need to verify that a JPEG2000 conversion produces the expected byte size for quality‑control or compliance reporting in an imaging workflow.
 */
