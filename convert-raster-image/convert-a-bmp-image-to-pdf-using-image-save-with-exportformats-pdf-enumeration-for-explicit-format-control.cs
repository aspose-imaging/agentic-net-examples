using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Export;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image and save it as PDF using explicit format enumeration
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, ExportFormats.Pdf);
        }
    }
}