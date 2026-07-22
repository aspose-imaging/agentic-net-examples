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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality 85
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Save the image as JPEG, preserving original dimensions
                image.Save(outputPath, saveOptions);
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
 * 1. When a desktop application needs to batch‑convert legacy BMP screenshots to smaller JPEG files for email attachments while keeping the original width and height and using a quality setting of 85.
 * 2. When a web service written in C# must receive user‑uploaded BMP images, compress them to JPEG with a controlled quality level, and store them in a file system without altering their dimensions.
 * 3. When an automated build script has to generate preview thumbnails from BMP assets by saving them as JPEGs at 85 % quality to reduce storage costs while preserving the exact pixel size.
 * 4. When a migration tool moves image data from an old Windows application that saved BMP files to a modern platform that requires JPEG format, ensuring the images retain their original resolution and a consistent quality factor.
 * 5. When a reporting engine creates charts as BMP files and then needs to embed them in PDF reports as JPEGs, using Aspose.Imaging in C# to convert the format with quality 85 and unchanged dimensions.
 */