using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
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

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the DjVu document from a file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
        {
            // Prepare TIFF saving options with Deflate compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Deflate
            };

            int pageIndex = 1;
            // Iterate through each page and save as an individual TIFF file
            foreach (DjvuPage page in djvuImage.Pages)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tiff");

                // Ensure the directory for this output file exists (already created above, but called per rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the current page as TIFF using the defined options
                page.Save(outputPath, tiffOptions);
                pageIndex++;
            }
        }
    }
}