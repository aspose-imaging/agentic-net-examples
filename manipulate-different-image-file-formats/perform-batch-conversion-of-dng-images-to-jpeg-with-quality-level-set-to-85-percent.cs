using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // Ensure output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputDir);

            // Get all DNG files in the input directory
            string[] dngFiles = Directory.GetFiles(inputDir, "*.dng", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in dngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path with .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists (covers cases where outputPath may include subfolders)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare JPEG save options with quality set to 85
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}