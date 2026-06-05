using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\LargeFile.eps";
            string outputPath = @"C:\Data\Converted\LargeFile.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with rasterization settings suitable for large files
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        // Define a reasonable page size to limit memory usage per tile
                        PageWidth = 2000,   // adjust as needed
                        PageHeight = 2000,  // adjust as needed
                        // Optional: set background color to white to avoid transparency issues
                        BackgroundColor = Color.White
                    }
                };

                // Save as PDF
                epsImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}