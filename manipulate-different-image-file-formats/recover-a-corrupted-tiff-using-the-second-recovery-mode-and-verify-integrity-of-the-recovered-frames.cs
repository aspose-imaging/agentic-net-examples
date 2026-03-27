using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
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

        // Prepare load options with second recovery mode
        var loadOptions = new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        };

        // Load the corrupted TIFF with recovery options
        using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
        {
            // Verify integrity of recovered frames
            Console.WriteLine($"Recovered frames count: {tiff.Frames.Length}");
            foreach (var frame in tiff.Frames)
            {
                Console.WriteLine($"Frame size: {frame.Width}x{frame.Height}");
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the recovered TIFF
            tiff.Save(outputPath);
        }
    }
}