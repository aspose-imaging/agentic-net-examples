using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "input.eps";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load EPS image for processing
        using (var image = Image.Load(inputPath))
        {
            // Example processing: display image dimensions
            Console.WriteLine($"Loaded EPS image. Width: {image.Width}, Height: {image.Height}");
        }
    }
}