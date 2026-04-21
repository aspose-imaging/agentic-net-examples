using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = "sample.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image and output its dimensions
        using (JpegImage jpeg = new JpegImage(inputPath))
        {
            Console.WriteLine($"Width: {jpeg.Width}");
            Console.WriteLine($"Height: {jpeg.Height}");
        }
    }
}