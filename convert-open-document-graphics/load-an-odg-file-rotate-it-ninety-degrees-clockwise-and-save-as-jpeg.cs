using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample_rotated.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image, rotate, and save as JPEG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access RotateFlip
                OdgImage odgImage = (OdgImage)image;
                odgImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                odgImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) diagram into a JPEG thumbnail for a web preview, they can load the ODG file, rotate it 90° clockwise, and save it as a JPEG using Aspose.Imaging for .NET.
 * 2. When integrating a document management system that stores drawings as ODG files but requires rotated JPEG images for printing or reporting, this code provides the necessary image loading, rotation, and format conversion.
 * 3. When building a batch processing tool that standardizes the orientation of ODG assets before publishing them to a content delivery network, the developer can use this snippet to rotate each ODG by 90 degrees and output JPEG files.
 * 4. When creating a desktop application that lets users view ODG illustrations in a photo viewer that only supports JPEG, the code enables loading the ODG, applying a clockwise rotation, and saving it as a JPEG image.
 * 5. When automating the generation of marketing materials where ODG logos must be rotated and embedded as JPEGs in email templates, this C# example demonstrates the required image manipulation with Aspose.Imaging.
 */