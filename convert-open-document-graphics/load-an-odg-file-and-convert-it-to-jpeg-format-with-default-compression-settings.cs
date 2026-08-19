// HOW-TO: Convert ODG to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "sample_converted.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare default JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save the image as JPEG
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
 * 1. When you need to display OpenDocument graphics on a website that only supports JPEG images.
 * 2. When an automated batch job must convert ODG design files to JPEG for inclusion in PDF reports.
 * 3. When a desktop application imports ODG drawings and saves them as JPEG thumbnails for quick preview.
 * 4. When a cloud service receives ODG uploads and must store them as compressed JPEG files to reduce storage costs.
 * 5. When a migration script transforms legacy ODG assets into JPEG format for compatibility with third‑party image editors.
 */
