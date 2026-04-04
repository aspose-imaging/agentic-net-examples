using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define image dimensions
        int width = 500;
        int height = 500;

        // Create a memory stream to hold the BMP data
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Set up BMP options with the stream as the output source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(memoryStream);

            // Create a BMP image bound to the memory stream
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Draw a thick green ellipse
                Pen greenPen = new Pen(Color.Green, 10); // thickness 10
                Rectangle ellipseBounds = new Rectangle(50, 50, 400, 400);
                graphics.DrawEllipse(greenPen, ellipseBounds);

                // Save the image to the bound stream
                image.Save();
            }

            // Retrieve the byte array from the memory stream
            byte[] bmpBytes = memoryStream.ToArray();

            // Example usage: output the size of the byte array
            Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
        }
    }
}