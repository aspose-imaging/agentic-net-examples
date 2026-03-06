using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = "sample.bmp";

        // Load the BMP image using Aspose.Imaging
        using (Image image = Image.Load(bmpPath))
        {
            // Create a MemoryStream to hold the BMP image data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the loaded image into the MemoryStream with default BMP options
                image.Save(memoryStream, new BmpOptions());

                // Reset the stream position if you need to read from it later
                memoryStream.Position = 0;

                // Example usage: output the size of the image data in the stream
                Console.WriteLine($"MemoryStream length: {memoryStream.Length} bytes");
            }
        }
    }
}