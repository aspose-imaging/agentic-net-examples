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
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Construct output file path for each page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tif");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set TIFF options with Deflate compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb);

                    // Save the page as TIFF
                    page.Save(outputPath, tiffOptions);

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}