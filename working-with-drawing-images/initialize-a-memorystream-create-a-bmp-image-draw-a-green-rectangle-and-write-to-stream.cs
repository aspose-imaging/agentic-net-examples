using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Initialize a memory stream to hold the BMP image.
            using (var memoryStream = new MemoryStream())
            {
                // Set up BMP options with the stream as the output source.
                var bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(memoryStream);

                // Create a BMP image of desired size.
                int width = 200;
                int height = 200;
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
                {
                    // Obtain a graphics object for drawing.
                    var graphics = new Aspose.Imaging.Graphics(image);

                    // Draw a green rectangle.
                    var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 5);
                    graphics.DrawRectangle(pen, 10, 10, 180, 180);

                    // Save changes; the image is bound to the memory stream.
                    image.Save();
                }

                // At this point, memoryStream contains the BMP data.
                // Example: output the length of the generated image.
                Console.WriteLine($"Generated BMP size: {memoryStream.Length} bytes");
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
 * 1. When generating a thumbnail preview of a document on the fly in a web API, a developer can use this code to create a BMP image in memory, draw a green border, and return the byte stream without writing to disk.
 * 2. When building a server‑side reporting tool that embeds a simple colored rectangle as a placeholder graphic, this snippet lets the developer produce a BMP image directly in a MemoryStream for embedding in PDF or email attachments.
 * 3. When implementing a real‑time image processing pipeline that needs to overlay a green rectangle on a blank canvas before sending it over a network socket, the code creates the BMP in memory and provides the raw bytes for transmission.
 * 4. When creating unit tests for graphics rendering logic, a developer can use this example to generate an in‑memory BMP with a known green rectangle and verify pixel data without persisting files.
 * 5. When developing a Windows service that logs visual status indicators as BMP files stored in a database BLOB column, this code draws the rectangle, writes the image to a MemoryStream, and supplies the byte array for database insertion.
 */