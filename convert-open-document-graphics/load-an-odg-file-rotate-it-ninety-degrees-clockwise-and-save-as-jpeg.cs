// HOW-TO: Rotate ODG Image 90 Degrees Clockwise and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample_converted.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access ODG-specific methods
                OdgImage odgImage = (OdgImage)image;

                // Rotate 90 degrees clockwise
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
 * 1. When you need to display an OpenDocument graphic in a web gallery that only supports JPEG, you can rotate the ODG file and convert it to JPEG using C#.
 * 2. When preparing printable assets from ODG drawings that must be oriented correctly for portrait layouts, you can programmatically rotate and save them as JPEGs.
 * 3. When automating batch processing of ODG diagrams for a reporting system that consumes JPEG thumbnails, this code rotates each diagram and creates the required JPEG files.
 * 4. When integrating legacy OpenDocument graphics into a mobile app that only renders JPEG images, you can use this snippet to reorient and convert the files on the server side.
 * 5. When generating image previews for an ODG file viewer that needs the preview rotated to match the original orientation, this C# routine loads, rotates, and saves the image as JPEG.
 */
