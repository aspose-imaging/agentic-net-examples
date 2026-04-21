using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\deskewed.pdf";

        // Ensure input file exists
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
            using (Image image = Image.Load(inputPath))
            {
                // Deskew the image using NormalizeAngle
                if (image is RasterImage rasterImage)
                {
                    // Do not resize, use LightGray as background
                    rasterImage.NormalizeAngle(false, Color.LightGray);
                }

                // Prepare PDF save options with smoothing mode
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        // Apply anti-alias smoothing
                        SmoothingMode = SmoothingMode.AntiAlias,
                        // Set page size to match the image dimensions
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        // Use white background for the PDF page
                        BackgroundColor = Color.White
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