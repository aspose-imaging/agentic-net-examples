using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tiff";
        string outputPath = @"C:\temp\output.tiff";

        // Input path validation as required
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists as required
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Instantiate GraphicsPath
        GraphicsPath graphicsPath = new GraphicsPath();

        // Verify that the default FillMode is Alternate
        bool isDefaultAlternate = graphicsPath.FillMode == FillMode.Alternate;

        // Output the verification result
        Console.WriteLine($"Default FillMode is Alternate: {isDefaultAlternate}");
    }
}