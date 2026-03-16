using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load an existing image from disk using the provided Load(Stream) rule
        using (FileStream fileStream = new FileStream(@"C:\temp\sample.bmp", FileMode.Open, FileAccess.Read))
        using (Image image = Image.Load(fileStream))
        {
            // Create a MemoryStream to hold the image's binary data in memory
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the loaded image into the MemoryStream using the provided Save(Stream, ImageOptionsBase) rule
                // Here we use PngOptions as an example; any appropriate ImageOptions can be used
                image.Save(memoryStream, new PngOptions());

                // At this point, memoryStream contains the image data and can be used for further in‑memory processing
                // For demonstration, reset the position to the beginning
                memoryStream.Position = 0;

                // Example: read the first few bytes (header) from the MemoryStream
                byte[] header = new byte[8];
                memoryStream.Read(header, 0, header.Length);
                Console.WriteLine("First 8 bytes of the image data: " + BitConverter.ToString(header));
            }
        }
    }
}