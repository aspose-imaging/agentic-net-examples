// HOW-TO: Rotate OTG Image 90 Degrees Clockwise and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output/output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
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
 * 1. When you need to display an OpenDocument graphics (OTG) file correctly in a web gallery that requires JPEG thumbnails rotated to portrait orientation.
 * 2. When converting scanned OTG diagrams into JPEG format for embedding in PDF reports while ensuring the image is rotated 90° clockwise to match the document layout.
 * 3. When automating batch processing of OTG assets to generate JPEG previews that are oriented for mobile devices.
 * 4. When integrating Aspose.Imaging into a C# application to transform legacy OTG graphics into JPEG for compatibility with image viewers that do not support OTG.
 * 5. When preparing OTG artwork for e‑commerce product listings, rotating it to the proper orientation and saving as a compressed JPEG for faster page loads.
 */
