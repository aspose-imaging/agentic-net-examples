using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image using the constructor that accepts a file path
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Output image dimensions
                Console.WriteLine($"Width: {jpegImage.Width}");
                Console.WriteLine($"Height: {jpegImage.Height}");
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}