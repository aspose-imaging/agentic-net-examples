// HOW-TO: Create BMP With Green Ellipse And Get Byte Array In C# (Aspose.Imaging for .NET)
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
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x400 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Create a thick green pen
                Pen pen = new Pen(Color.Green, 8);

                // Draw an ellipse
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 400, 300));

                // Save changes (file is already bound to the source)
                image.Save();
            }

            // Export the image as a byte array
            byte[] imageBytes = File.ReadAllBytes(outputPath);
            Console.WriteLine($"Image saved to {outputPath} ({imageBytes.Length} bytes).");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a BMP thumbnail with a highlighted green ellipse for a reporting dashboard and send the image data over a web API.
 * 2. When an automated testing tool must create a sample BMP file with a specific shape to validate image‑processing pipelines.
 * 3. When a desktop application requires drawing a thick green ellipse on a blank canvas and storing the result in memory for further manipulation without keeping a temporary file.
 * 4. When you want to embed a dynamically drawn BMP graphic into an email attachment by converting the file to a byte array first.
 * 5. When a game server needs to produce simple BMP sprites with geometric markers and transmit them to clients as byte streams.
 */
