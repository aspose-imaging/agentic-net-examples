using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input PDF path
        string inputPath = @"C:\temp\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Loop over pages 1 to 3 (zero‑based indices 0,1,2)
        for (int pageIndex = 0; pageIndex < 3; pageIndex++)
        {
            // Construct output TIFF path for each page
            string outputPath = $@"C:\temp\output_page{pageIndex + 1}.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Configure TIFF save options with MultiPageOptions for a single page
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.MultiPageOptions = new MultiPageOptions(new int[] { pageIndex });

                // Save the selected page as a separate TIFF file
                pdfImage.Save(outputPath, tiffOptions);
            }
        }
    }
}