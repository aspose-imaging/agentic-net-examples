using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

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

            // Prepare load options for second recovery mode
            LoadOptions loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            // Load the corrupted TIFF with recovery options
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                // Verify integrity: output number of recovered frames and their dimensions
                int frameCount = tiffImage.Frames.Length;
                Console.WriteLine($"Recovered frames: {frameCount}");
                for (int i = 0; i < frameCount; i++)
                {
                    var frame = tiffImage.Frames[i];
                    Console.WriteLine($"Frame {i + 1}: {frame.Width}x{frame.Height}");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the recovered TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}