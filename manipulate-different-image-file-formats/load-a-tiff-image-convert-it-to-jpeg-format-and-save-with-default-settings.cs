using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Save as JPEG with default options
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to batch‑convert scanned TIFF documents to JPEG for faster web preview, they can use this code to load each .tif file and save it as a .jpg with default compression.
 * 2. When integrating a legacy medical imaging system that outputs TIFF files, a C# application can employ this snippet to transform the images into JPEG format for display in modern browsers.
 * 3. When an automated report generator creates high‑resolution TIFF charts, the code can be used to convert those charts to JPEG to reduce file size before emailing the report.
 * 4. When a digital asset management tool receives user‑uploaded TIFF photos, the developer can apply this routine to store a JPEG thumbnail version for quick browsing.
 * 5. When migrating a file archive from a Windows server, this example lets a developer read each TIFF file and save it as JPEG to ensure compatibility with mobile devices.
 */