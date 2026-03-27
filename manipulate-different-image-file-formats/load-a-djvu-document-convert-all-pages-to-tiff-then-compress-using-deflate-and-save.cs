using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            int pageIndex = 0;
            foreach (var pageObj in djvuImage.Pages)
            {
                // Each page is a DjvuPage
                var page = (DjvuPage)pageObj;

                // Build output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure TIFF options with Deflate compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;

                // Save the page as a TIFF file
                page.Save(outputPath, tiffOptions);

                pageIndex++;
            }
        }
    }
}