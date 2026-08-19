// HOW-TO: Save BMP As PNG To MemoryStream For Network Transfer In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hard‑coded input and (unused) output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (required by the safety rules)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the image to a memory stream for network transmission
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // The stream now contains the PNG data; reset position if needed
                    memoryStream.Position = 0;

                    // Example usage: output the size of the generated PNG
                    Console.WriteLine($"PNG image size in bytes: {memoryStream.Length}");
                    
                    // At this point the memoryStream can be sent over a network
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a BMP file to a PNG and send it directly over HTTP without writing a temporary file to disk.
 * 2. When a web service must return an image generated from a legacy bitmap as a PNG stream to a client application.
 * 3. When you are building a real‑time image processing pipeline that compresses BMP frames to PNG and streams them to a remote viewer.
 * 4. When an API endpoint has to embed a PNG image in a JSON payload, requiring the image data to be held in memory first.
 * 5. When you want to measure the size of a PNG conversion before uploading it to cloud storage, using a MemoryStream to avoid extra I/O.
 */
