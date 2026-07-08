using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load WebP image from a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(fileBytes))
            using (WebPImage webPImage = new WebPImage(inputStream))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as GIF
                webPImage.Save(outputPath, new GifOptions());
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
 * 1. When a web application receives an uploaded WebP image as a byte array and must deliver an animated GIF to browsers that do not support WebP, the developer can use this code to convert the image directly from a MemoryStream to a GIF file.
 * 2. When a background service processes image assets stored in a database as BLOBs and needs to generate GIF thumbnails for email newsletters, the code enables conversion without writing temporary files to disk.
 * 3. When a mobile backend API receives WebP screenshots from iOS devices and must store them as GIFs for compatibility with legacy reporting tools, the developer can stream the bytes and save them as GIF using Aspose.Imaging.
 * 4. When an automated build pipeline extracts WebP assets from a zip archive and must package them as GIFs for inclusion in a Windows desktop application, this in‑memory conversion avoids extra I/O overhead.
 * 5. When a cloud function triggered by a storage event reads a WebP image from a blob storage stream and must output a GIF for downstream image‑processing workflows, the code provides a fast, file‑less transformation.
 */