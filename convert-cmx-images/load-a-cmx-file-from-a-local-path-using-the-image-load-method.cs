using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.cmx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to CmxImage to access CMX‑specific properties
            if (image is CmxImage cmxImage)
            {
                Console.WriteLine($"CMX image loaded successfully.");
                Console.WriteLine($"Width: {cmxImage.Width} pixels");
                Console.WriteLine($"Height: {cmxImage.Height} pixels");
                Console.WriteLine($"Page count: {cmxImage.PageCount}");
            }
            else
            {
                Console.WriteLine("The loaded image is not a CMX image.");
            }
        }
    }
}