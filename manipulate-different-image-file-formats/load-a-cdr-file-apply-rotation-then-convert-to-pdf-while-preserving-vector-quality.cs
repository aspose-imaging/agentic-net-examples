using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_rotated.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Apply rotation (e.g., 90 degrees clockwise)
                image.Rotate(90f);

                // Prepare PDF save options with vector rasterization settings
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        // Preserve vector quality by using document-defined positioning
                        Positioning = PositioningTypes.DefinedByDocument,
                        // Optional: set smoothing mode and text rendering hint as needed
                        SmoothingMode = SmoothingMode.None,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    }
                };

                // Save the rotated image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}