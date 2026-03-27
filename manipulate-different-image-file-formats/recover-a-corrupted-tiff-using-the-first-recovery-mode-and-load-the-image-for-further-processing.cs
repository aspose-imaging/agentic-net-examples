using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "corrupted.tif";
        string outputPath = "recovered.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set recovery options (first recovery mode)
        var loadOptions = new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        };

        // Load the corrupted TIFF with recovery and process it
        using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
        {
            // Example processing: output image dimensions
            Console.WriteLine($"Recovered image size: {tiff.Width}x{tiff.Height}");

            // Save the recovered image
            tiff.Save(outputPath);
        }
    }
}