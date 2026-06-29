using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Wrap the whole process in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.jpg";

            // Verify that the input EMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare JPEG save options with EXIF metadata
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Set desired JPEG quality (optional)
                    Quality = 90,

                    // Create and assign EXIF data (camera information)
                    ExifData = new JpegExifData
                    {
                        Make = "Canon",               // Camera manufacturer
                        Model = "EOS 5D Mark IV",    // Camera model
                        // Additional optional EXIF fields can be set here
                        // For example:
                        // DateTimeOriginal = DateTime.Now,
                        // FNumber = 2.8,
                        // ExposureTime = 0.005,
                        // ISO = 100
                    }
                };

                // Save the image as JPEG with the specified options
                emfImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any error messages without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop publishing application needs to export vector EMF diagrams as high‑resolution JPEG thumbnails while preserving camera make and model information for downstream cataloging.
 * 2. When an automated reporting system generates charts in EMF format and must convert them to JPEG for email attachment, embedding EXIF data so the recipient can see the originating device details.
 * 3. When a legacy engineering workflow stores schematics as EMF files and a migration tool must produce JPEG images with EXIF metadata to integrate with modern asset‑management databases that rely on camera metadata fields.
 * 4. When a web service receives user‑uploaded EMF logos and needs to create JPEG previews with embedded EXIF tags so SEO tools can index the image with camera make and model attributes.
 * 5. When a batch processing script runs in C# to convert a folder of EMF drawings to JPEG files and adds EXIF camera information to satisfy compliance requirements that mandate metadata for all exported images.
 */