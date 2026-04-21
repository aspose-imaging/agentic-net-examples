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
            string inputPath = "Corrupted.tif";
            string outputPath = "Recovered.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Set load options to use the first recovery mode (ConsistentRecover)
            LoadOptions loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            // Load the corrupted TIFF with recovery options
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                // Further processing can be done here (e.g., inspect dimensions)
                Console.WriteLine($"Recovered image size: {tiff.Width}x{tiff.Height}");

                // Save the recovered image
                tiff.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}