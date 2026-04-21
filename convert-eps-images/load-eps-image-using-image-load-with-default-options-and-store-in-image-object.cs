using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS file path
        string inputPath = @"C:\temp\sample.eps";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the EPS image using default load options
        using (Image image = Image.Load(inputPath))
        {
            // The loaded image is stored in the 'image' variable.
            // Example: output basic information about the image.
            Console.WriteLine($"Image loaded successfully.");
            Console.WriteLine($"Width: {image.Width} px, Height: {image.Height} px");
            Console.WriteLine($"File format: {image.FileFormat}");
        }

        // Example output path (not used for saving in this task)
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists before any potential save operation
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
    }
}