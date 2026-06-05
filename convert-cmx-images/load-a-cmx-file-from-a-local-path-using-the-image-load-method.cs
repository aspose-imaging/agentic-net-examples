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

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Example: output some basic information about the loaded image
                Console.WriteLine($"Loaded CMX image:");
                Console.WriteLine($"- Width: {image.Width} pixels");
                Console.WriteLine($"- Height: {image.Height} pixels");
                Console.WriteLine($"- Page count: {image.PageCount}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}