using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the image from the file system
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Save the image to a memory stream for network transmission
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // Example usage: display the size of the generated PNG data
                    Console.WriteLine($"PNG image size in bytes: {memoryStream.Length}");
                    
                    // The memoryStream now contains the PNG data and can be sent over a network
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}