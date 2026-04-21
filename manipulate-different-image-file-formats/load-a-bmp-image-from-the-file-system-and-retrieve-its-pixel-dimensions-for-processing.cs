using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.bmp";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image using Aspose.Imaging
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            // Retrieve pixel dimensions
            int width = bmpImage.Width;
            int height = bmpImage.Height;

            // Output dimensions
            Console.WriteLine($"Image dimensions: {width} x {height}");
        }
    }
}