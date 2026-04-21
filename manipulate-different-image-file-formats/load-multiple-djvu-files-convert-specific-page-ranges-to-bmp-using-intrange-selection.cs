using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu files
        string[] inputPaths = {
            "Input/file1.djvu",
            "Input/file2.djvu"
        };

        // Define the page range to export (e.g., pages 2 to 4)
        int startPage = 2; // inclusive, zero-based index
        int endPage = 4;   // inclusive

        // Output directory
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Construct output file path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_pages.bmp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu image
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Set BMP save options with page range selection
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(startPage, endPage));

                // Save selected pages as a BMP file
                djvu.Save(outputPath, bmpOptions);
            }
        }
    }
}