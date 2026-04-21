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
        try
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

            // Load the corrupted TIFF with recovery options
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                // Verify integrity of recovered frames
                Console.WriteLine($"Recovered frame count: {tiff.Frames.Length}");
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    var frame = tiff.Frames[i];
                    Console.WriteLine($"Frame {i}: {frame.Width}x{frame.Height}");
                }

                // Save the recovered TIFF
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}