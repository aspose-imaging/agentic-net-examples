using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define image dimensions
            int width = 500;
            int height = 500;

            // Create a BMP image with default options
            BmpOptions createOptions = new BmpOptions();
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(createOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw a thick green ellipse
                Aspose.Imaging.Pen greenPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 10);
                graphics.DrawEllipse(greenPen, new Aspose.Imaging.Rectangle(50, 50, 400, 300));

                // Export the image to a byte array using a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the image into the stream with BMP options
                    image.Save(ms, new BmpOptions());

                    byte[] imageBytes = ms.ToArray();
                    Console.WriteLine($"Image exported as byte array. Length: {imageBytes.Length}");
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
 * 1. When a developer must generate a BMP image with a thick green ellipse for a medical report thumbnail and transmit it via a web API as a byte array.
 * 2. When an e‑commerce platform needs to create on‑the‑fly product placeholders in BMP format with a green ellipse overlay and store them in a database as binary data.
 * 3. When a desktop application requires drawing a green elliptical selection area on a BMP canvas and saving the result directly to memory for further processing without writing to disk.
 * 4. When a game engine tool needs to export a BMP sprite sheet containing a green ellipse shape as a byte array to embed in resource files.
 * 5. When an automated testing suite must generate a BMP image with a green ellipse to validate image‑processing algorithms and compare the resulting byte array against expected values.
 */