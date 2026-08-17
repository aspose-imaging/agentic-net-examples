// HOW-TO: Create BMP Image With Green Rectangle Using MemoryStream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths for compliance
            string inputPath = "input.bmp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Initialize a memory stream to hold the BMP image
            using (MemoryStream stream = new MemoryStream())
            {
                // Set up BMP options with the stream as the source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                // Create a 200x200 BMP image
                using (Image image = Image.Create(bmpOptions, 200, 200))
                {
                    // Obtain a graphics object for drawing
                    Graphics graphics = new Graphics(image);

                    // Draw a green rectangle
                    graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(50, 50, 100, 100));

                    // Save the image data to the bound stream
                    image.Save();
                }

                // At this point the stream contains the BMP data
                Console.WriteLine($"Generated BMP size: {stream.Length} bytes");
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
 * 1. When you need to generate a BMP thumbnail with a highlighted area on the fly without writing temporary files to disk.
 * 2. When you want to embed a simple graphic, such as a green bounding box, into a memory stream for further processing or transmission over a network.
 * 3. When creating a placeholder image for reports or UI components where the image must be created programmatically and saved as BMP.
 * 4. When you need to draw shapes onto an image using Aspose.Imaging’s Graphics API and keep the result in memory for later conversion to another format.
 * 5. When implementing a server‑side service that produces BMP images with custom annotations and returns the byte array directly to the client.
 */
