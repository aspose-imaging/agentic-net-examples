using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.webp";
            string outputPath = @"c:\temp\rotated.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate 90 degrees clockwise without resizing the canvas
                webPImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as BMP
                webPImage.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to display a WebP screenshot taken in portrait orientation on a legacy Windows application that only supports BMP files, they can rotate the image 90 degrees and convert it to BMP.
 * 2. When an automated batch‑processing pipeline must prepare user‑uploaded WebP avatars for printing on label printers that require BMP input, the code can rotate the image and save it in the required format.
 * 3. When a mobile game assets pipeline receives WebP textures oriented incorrectly and the game engine only reads BMP textures, the developer can rotate the texture and export it as BMP.
 * 4. When a document generation system extracts WebP diagrams from a web service, needs to align them to landscape layout, and embeds them into PDFs that only accept BMP images, this code performs the rotation and conversion.
 * 5. When a digital forensics tool analyzes WebP images from a camera, must normalize orientation to a standard view, and stores the results as BMP for compatibility with older analysis software, the code provides the needed transformation.
 */