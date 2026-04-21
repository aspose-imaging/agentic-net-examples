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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Instantiate a GraphicsPath object
        GraphicsPath graphicsPath = new GraphicsPath();

        // Confirm the default FillMode is Alternate
        if (graphicsPath.FillMode == FillMode.Alternate)
        {
            Console.WriteLine("Default FillMode is Alternate.");
        }
        else
        {
            Console.WriteLine($"Default FillMode is {graphicsPath.FillMode}.");
        }
    }
}