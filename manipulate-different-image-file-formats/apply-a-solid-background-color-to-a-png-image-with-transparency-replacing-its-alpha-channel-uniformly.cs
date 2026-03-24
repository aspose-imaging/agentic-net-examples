using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Set a solid background color (e.g., white) and enable it
            pngImage.BackgroundColor = Aspose.Imaging.Color.White;
            pngImage.HasBackgroundColor = true;

            // Save the modified image
            pngImage.Save(outputPath);
        }
    }
}