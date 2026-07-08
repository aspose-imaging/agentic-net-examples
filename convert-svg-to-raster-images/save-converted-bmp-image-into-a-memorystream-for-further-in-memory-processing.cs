using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Example processing: rotate the image 180 degrees around X axis
                image.RotateFlip(RotateFlipType.Rotate180FlipX);

                // Prepare BMP save options (default settings)
                BmpOptions saveOptions = new BmpOptions();

                // Save the processed image into a MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, saveOptions);

                    // The stream now contains the BMP data; it can be used for further in‑memory processing
                    Console.WriteLine($"Image saved to MemoryStream. Size in bytes: {memoryStream.Length}");
                    
                    // Example of resetting the position if further reading is needed
                    memoryStream.Position = 0;
                    // ... further processing of memoryStream ...
                }
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
 * 1. When a web service needs to receive a BMP file, rotate it, and return the modified image without writing to disk, a developer can load the BMP with Aspose.Imaging, apply RotateFlip, and save it to a MemoryStream for immediate transmission.
 * 2. When generating a PDF report that embeds a processed BMP image, a developer can keep the image in a MemoryStream to feed it directly into the PDF library without creating temporary files.
 * 3. When performing batch image transformations in a background worker and storing the results in a database as BLOBs, a developer can use the MemoryStream to capture the BMP bytes and insert them into the database.
 * 4. When integrating with a third‑party API that expects image data as a byte array, a developer can convert the rotated BMP to a MemoryStream and then call ToArray() to supply the required payload.
 * 5. When implementing an in‑memory caching layer for frequently accessed BMP thumbnails, a developer can load, rotate, and save the image to a MemoryStream so the cached byte array can be served quickly without disk I/O.
 */