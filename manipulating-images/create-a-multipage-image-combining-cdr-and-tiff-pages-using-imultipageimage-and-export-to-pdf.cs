using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string cdrPath = "Input/sample.cdr";
            string tiffPath = "Input/sample.tif";
            string outputPath = "Output/combined.pdf";

            // Validate input files
            if (!File.Exists(cdrPath))
            {
                Console.Error.WriteLine($"File not found: {cdrPath}");
                return;
            }
            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR and TIFF images
            using (CdrImage cdrImage = (CdrImage)Image.Load(cdrPath))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffPath))
            {
                // Create a multipage image from the two source images
                using (Image multipage = Image.Create(new Image[] { cdrImage, tiffImage }))
                {
                    // Export the combined pages to PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    multipage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}