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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Input\LargeFile.eps";
            string outputPath = @"C:\Output\LargeFile.pdf";

            // Verify that the source EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image with a buffer size hint to limit memory usage
            var loadOptions = new EpsLoadOptions
            {
                // Example hint: 100 MB maximum internal buffer size
                BufferSizeHint = 100 * 1024 * 1024
            };

            using (var epsImage = (EpsImage)Image.Load(inputPath, loadOptions))
            {
                // Configure PDF conversion options
                var pdfOptions = new PdfOptions
                {
                    // Set PDF compliance if required
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },

                    // Use vector rasterization options to control how the EPS is rendered.
                    // Setting PageWidth/PageHeight to the original dimensions keeps the
                    // rasterization in a single tile; for very large files you could
                    // split the rendering into smaller tiles by adjusting these values.
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height
                    }
                };

                // Save the EPS as a PDF using the configured options
                epsImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}