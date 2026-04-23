using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Configure TIFF options with Deflate compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;

                // Iterate through all pages and save each as a TIFF file
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    Image page = djvuImage.Pages[i];
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as TIFF using the configured options
                    page.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}