// HOW-TO: Convert HTML5 Canvas Image Stream To JPEG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.html";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                using (Image image = Image.Load(inputStream))
                {
                    // Configure JPEG save options (optional settings)
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90 // Set desired quality (1-100)
                    };

                    // Save the image as JPEG
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a JPEG thumbnail from an HTML5 canvas that is stored in a file or received as a stream in a C# web service.
 * 2. When you want to save a dynamically created canvas drawing from a browser‑based editor to a JPEG file on the server using Aspose.Imaging.
 * 3. When you have to batch‑process HTML5 canvas files and convert them to JPEG for archival or reporting purposes in a .NET application.
 * 4. When you need to ensure the output JPEG meets a specific quality level (e.g., 90) while converting canvas graphics for email attachments.
 * 5. When you are building an API that accepts canvas data via a stream and must return a JPEG image for downstream systems or third‑party services.
 */
