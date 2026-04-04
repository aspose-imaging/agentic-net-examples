using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Initialize a memory stream that will hold the BMP image data
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Configure BMP options to write directly to the memory stream
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(memoryStream);

            // Create a 200x200 BMP image bound to the memory stream
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Obtain a Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Draw a green rectangle (position 20,20; size 160x160) with a 3‑pixel pen
                graphics.DrawRectangle(new Pen(Color.Green, 3), new Rectangle(20, 20, 160, 160));

                // Save the image; since the image is bound to the stream, no path is needed
                image.Save();
            }

            // The memory stream now contains the BMP image bytes
            Console.WriteLine($"BMP image size in bytes: {memoryStream.Length}");
        }
    }
}