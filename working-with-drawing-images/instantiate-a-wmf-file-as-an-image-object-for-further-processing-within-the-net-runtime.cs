using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.wmf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF file and obtain a WmfImage instance for further processing
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to a WmfImage
            WmfImage wmfImage = (WmfImage)image;

            // Example processing could be placed here (e.g., resizing, drawing, etc.)

            // Save the (potentially modified) WMF image to the output path
            wmfImage.Save(outputPath);
        }
    }
}