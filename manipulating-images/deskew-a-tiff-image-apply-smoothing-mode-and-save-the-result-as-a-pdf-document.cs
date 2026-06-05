using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (do not resize, use light gray background)
                image.NormalizeAngle(false, Color.LightGray);

                // Prepare PDF save options with smoothing mode
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                    }
                };

                // Save the processed image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}