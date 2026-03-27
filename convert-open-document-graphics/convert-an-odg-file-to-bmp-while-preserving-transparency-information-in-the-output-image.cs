using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare BMP save options (default compression Bitfields preserves transparency)
            BmpOptions bmpOptions = new BmpOptions();

            // Save the image as BMP preserving alpha channel
            odgImage.Save(outputPath, bmpOptions);
        }
    }
}