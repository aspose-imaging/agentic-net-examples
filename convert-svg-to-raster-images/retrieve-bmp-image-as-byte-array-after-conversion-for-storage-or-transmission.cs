using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = "Input/sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Save the image to a memory stream in BMP format
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(memoryStream, bmpOptions);

                // Retrieve the byte array
                byte[] bmpBytes = memoryStream.ToArray();

                // Example usage of the byte array
                Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
                // The byte array can now be stored or transmitted as needed
            }
        }
    }
}