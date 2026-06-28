using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image, rotate, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                webPImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the transformed image to BMP format
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
 * 1. When a developer must show a WebP photo in an older Windows desktop program that only accepts BMP files, they can rotate the image 90° clockwise and convert it to BMP.
 * 2. When a batch‑processing script needs to correct the orientation of WebP screenshots taken in landscape mode before archiving them as BMP for compatibility with a reporting tool.
 * 3. When an e‑commerce site stores product images as WebP but a third‑party inventory system requires BMP files, the code can reorient and export the images in one step.
 * 4. When a mobile app uploads user‑generated WebP graphics that need to be displayed on a kiosk running .NET, the developer can rotate the image and save it as BMP for the kiosk’s display engine.
 * 5. When a digital asset management workflow includes a quality‑check that expects BMP thumbnails, the code can automatically rotate misaligned WebP files and generate the required BMP thumbnails.
 */