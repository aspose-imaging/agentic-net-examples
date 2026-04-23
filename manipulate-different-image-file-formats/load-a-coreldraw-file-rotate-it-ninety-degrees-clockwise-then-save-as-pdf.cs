using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "sample_rotated.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare PDF save options with rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}