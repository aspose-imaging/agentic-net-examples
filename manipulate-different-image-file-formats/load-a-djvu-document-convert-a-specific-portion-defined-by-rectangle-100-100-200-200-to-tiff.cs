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
            string outputPath = "Output/portion.tiff";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Define the rectangle area to export (x, y, width, height)
                Rectangle exportArea = new Rectangle(100, 100, 200, 200);

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                // Export only the first page (index 0) with the specified area
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(0, exportArea);

                // Save the selected portion as TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}