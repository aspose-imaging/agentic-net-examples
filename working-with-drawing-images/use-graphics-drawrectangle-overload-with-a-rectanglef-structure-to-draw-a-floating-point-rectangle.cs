using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as the source
            PngOptions pngOptions = new PngOptions
            {
                Source = new StreamSource(stream)
            };

            // Create a new image with the specified dimensions
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the background
                graphics.Clear(Color.Wheat);

                // Define a pen for the rectangle
                Pen pen = new Pen(Color.Blue, 2);

                // Define a floating‑point rectangle
                RectangleF rectF = new RectangleF(50f, 50f, 200f, 150f);

                // Draw the rectangle using the RectangleF overload
                graphics.DrawRectangle(pen, rectF);

                // Save changes to the image
                image.Save();
            }
        }
    }
}