using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP file path
        string inputPath = @"C:\Images\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image using the BmpImage constructor
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            // Retrieve pixel dimensions
            int width = bmpImage.Width;
            int height = bmpImage.Height;

            // Output the dimensions
            Console.WriteLine($"Image dimensions: {width} x {height}");
        }

        // Example of an output path (not required for just reading dimensions)
        // Demonstrates the required directory creation rule before any save operation
        string outputPath = @"C:\Images\output\dummy.txt";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        // No actual save performed here as the task only requires reading dimensions
    }
}