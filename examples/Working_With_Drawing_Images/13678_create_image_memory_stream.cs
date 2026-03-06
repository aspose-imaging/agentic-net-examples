using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load an image from a file (replace with your actual file path)
        using (Image image = Image.Load(@"C:\temp\sample.bmp"))
        {
            // Create a MemoryStream that will hold the image data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the image into the MemoryStream using PNG format options
                image.Save(memoryStream, new PngOptions());

                // Reset the stream position if you need to read from it later
                memoryStream.Position = 0;

                // Example usage: output the size of the stream in bytes
                Console.WriteLine($"MemoryStream length: {memoryStream.Length} bytes");
            }
        }
    }
}