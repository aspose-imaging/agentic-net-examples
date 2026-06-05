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

            // Load WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate image 180 degrees, resize proportionally, white background
                webPImage.Rotate(180f, true, Aspose.Imaging.Color.White);

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
 * 1. When a developer needs to convert user‑uploaded WebP avatars to BMP for legacy Windows applications that only accept BMP files, they can load the WebP, rotate it 180°, and save as BMP.
 * 2. When an image‑processing service must correct the orientation of WebP screenshots taken on mobile devices before storing them in a BMP‑based archival system, this code performs the 180° rotation and format conversion.
 * 3. When a game engine requires textures in BMP format and the source assets are supplied as WebP, a developer can use this snippet to rotate the texture 180° to match the engine’s coordinate system and save it as BMP.
 * 4. When a batch job needs to prepare WebP product photos for printing on equipment that only reads BMP files and expects the image upside‑down, the code loads the WebP, applies a 180° rotation and outputs BMP.
 * 5. When a document‑generation tool must embed a WebP logo into a BMP‑only template and ensure the logo appears correctly oriented, this code loads the WebP, rotates it 180°, and saves it as BMP.
 */