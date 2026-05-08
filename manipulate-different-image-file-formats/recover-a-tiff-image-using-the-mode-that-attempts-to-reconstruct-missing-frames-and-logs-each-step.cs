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
            // Hardcoded input and output file paths
            string inputPath = "input.tif";
            string outputPath = "recovered.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional call as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Console.WriteLine("Loading TIFF with recovery mode...");

            // Configure load options to attempt reconstruction of missing frames
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover
            };

            // Load the TIFF image using the recovery options
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                Console.WriteLine($"Loaded TIFF. Frame count: {tiff.Frames.Length}");

                // Prepare save options (default format)
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);

                Console.WriteLine("Saving recovered TIFF...");

                // Save the recovered image
                tiff.Save(outputPath, saveOptions);

                Console.WriteLine("Recovery complete.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}