using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Initialize a memory stream to hold the BMP image data
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Set up BMP options and bind the stream as the image source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(memoryStream);

            // Create a 200x200 BMP image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Draw a green rectangle with a 2-pixel pen
                graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(20, 20, 160, 160));

                // Save the image; since the image is bound to the stream, no path is needed
                image.Save();
            }

            // At this point, memoryStream contains the BMP image bytes
            // (Optional) Example of writing the stream to a file for verification
            // string outputPath = "output.bmp";
            // Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            // File.WriteAllBytes(outputPath, memoryStream.ToArray());
        }
    }
}