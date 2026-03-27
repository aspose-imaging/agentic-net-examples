using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all DjVu files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

        int processed = 0;
        foreach (string inputPath in files)
        {
            // Limit to 30 files
            if (processed >= 30)
                break;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output file path with .tif extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu image and save as TIFF
            using (Image image = Image.Load(inputPath))
            {
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    image.Save(outputPath, tiffOptions);
                }
            }

            processed++;
        }
    }
}