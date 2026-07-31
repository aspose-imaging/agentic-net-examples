using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define image dimensions
            int width = 200;
            int height = 200;

            // Create BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a thick green pen
                Pen pen = new Pen(Color.Green, 5);

                // Draw an ellipse
                graphics.DrawEllipse(pen, new Rectangle(20, 20, 160, 160));

                // Export image to a byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the image to the memory stream using BMP options
                    image.Save(ms, new BmpOptions());

                    byte[] imageBytes = ms.ToArray();

                    // Optional: write the byte array to a file for verification
                    string outputPath = "output.bmp";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
                    File.WriteAllBytes(outputPath, imageBytes);
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
 * 1. When a developer needs to generate a BMP thumbnail with a highlighted thick green ellipse for a document preview in a C# web application.
 * 2. When an automated reporting tool must embed a simple vector shape into a BMP image and transmit it as a byte array over a network API.
 * 3. When a desktop utility creates a printable BMP badge that includes a thick green ellipse as a visual marker and stores the image in memory for further processing.
 * 4. When a cloud service converts dynamically drawn graphics into BMP byte streams for storage in a database without writing intermediate files.
 * 5. When a game engine loads custom UI elements from BMP byte arrays generated at runtime, such as a green ellipse button background.
 */