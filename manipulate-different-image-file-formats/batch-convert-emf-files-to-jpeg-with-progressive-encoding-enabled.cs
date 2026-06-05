using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path with .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure JPEG options with progressive compression
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        Quality = 100
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
 * 1. When a developer needs to migrate a legacy collection of vector EMF graphics to web‑friendly JPEG images with progressive loading for faster page rendering.
 * 2. When an automated build process must generate high‑quality JPEG thumbnails from EMF diagrams stored in a shared folder for inclusion in reports.
 * 3. When a Windows desktop application has to batch convert user‑uploaded EMF files to JPEG while preserving image quality and enabling progressive compression for email attachments.
 * 4. When a server‑side service processes design assets, converting EMF logos to JPEG format with 100 % quality and progressive encoding to reduce bandwidth usage on mobile devices.
 * 5. When a migration script needs to ensure all EMF files in a directory are saved as JPEGs with progressive compression before archiving them to a cloud storage bucket.
 */