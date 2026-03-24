using System;
using System.IO;
using Aspose.Imaging;

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

        // Load the image into memory using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Image is now ready for further processing
            Console.WriteLine($"Image loaded successfully. Width: {image.Width}, Height: {image.Height}");
            // Additional image operations can be performed here
        }
    }
}