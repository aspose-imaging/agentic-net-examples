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
            string inputPath = "sample.bmp";
            string outputPath = "output/sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with desired quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85 // Adjust quality (1-100) as needed
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a C# developer needs to reduce the file size of high‑resolution BMP screenshots for faster web page loading, they can use Aspose.Imaging to convert the BMP to a JPEG with a configurable quality setting.
 * 2. When building a .NET desktop application that archives scanned documents, the code enables automatic conversion of BMP scans to JPEGs while preserving visual fidelity by adjusting the compression level.
 * 3. When creating an email‑sending service in C#, the developer can transform BMP attachments into JPEG format with a chosen quality to stay within attachment size limits.
 * 4. When a photo‑management tool must generate thumbnail previews, the BMP images can be batch‑converted to JPEG using Aspose.Imaging’s JpegOptions to control the balance between image clarity and storage space.
 * 5. When integrating a cloud‑based image‑processing API, the code allows the service to accept BMP uploads and return JPEG outputs with a specified quality, ensuring consistent results across different client applications.
 */