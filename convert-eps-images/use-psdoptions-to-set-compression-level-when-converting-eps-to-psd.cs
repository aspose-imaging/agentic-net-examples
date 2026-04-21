using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.eps";
        string outputPath = @"C:\temp\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD options with desired compression
            PsdOptions psdOptions = new PsdOptions
            {
                // Set compression method (RLE or Raw)
                CompressionMethod = CompressionMethod.RLE
            };

            // Save the image as PSD using the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}