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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_rotated.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
 * 1. When a developer needs to convert legacy OpenDocument graphics (OTG) files into web‑friendly JPEGs while correcting orientation, they can load the OTG, rotate it 90° clockwise, and save as JPEG using Aspose.Imaging for .NET.
 * 2. When an automated document processing pipeline must generate thumbnail previews of OTG diagrams for a gallery view, the code can rotate the image and output a JPEG thumbnail.
 * 3. When a batch job processes scanned engineering drawings stored as OTG and requires them to be reoriented for printing, the developer can use this snippet to rotate and save each file as a JPEG.
 * 4. When integrating a C# desktop application that lets users upload OTG graphics and immediately view them in standard image viewers, the code rotates the image and converts it to JPEG on the fly.
 * 5. When a server‑side service receives OTG files from mobile devices and must store them in a compressed JPEG format with correct orientation for downstream analytics, the example demonstrates the necessary steps.
 */