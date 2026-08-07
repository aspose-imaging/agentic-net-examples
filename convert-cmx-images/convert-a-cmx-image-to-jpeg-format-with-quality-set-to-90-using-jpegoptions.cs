using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cmx";
        string outputPath = @"C:\temp\sample.jpg";

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

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality = 90
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

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
 * 1. When a developer needs to convert legacy CorelDRAW CMX files to web‑friendly JPEG images with a specific compression quality for display on a website.
 * 2. When an automated batch process must read CMX drawings from a folder, ensure the output directory exists, and save them as JPEG with quality 90 for consistent preview generation.
 * 3. When a C# application uses Aspose.Imaging to create high‑quality JPEG previews of CMX artwork for inclusion in email attachments or PDF reports.
 * 4. When a migration tool has to verify the presence of source CMX files, create missing output folders, and reliably save them as JPEG using JpegOptions to control image fidelity.
 * 5. When a Windows service monitors a drop‑box, loads incoming CMX files, and converts them to JPEG with a 90 % quality setting to maintain visual consistency across downstream systems.
 */