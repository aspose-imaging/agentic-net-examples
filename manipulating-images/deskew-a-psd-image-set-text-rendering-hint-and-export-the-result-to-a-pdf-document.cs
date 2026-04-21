using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.psd");
            string outputPath = Path.Combine("Output", "result.pdf");
            string tempTiffPath = Path.Combine("Output", "temp.tif");

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Save PSD as temporary TIFF for deskewing
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                psdImage.Save(tempTiffPath, tiffOptions);
            }

            // Load temporary TIFF and deskew
            using (TiffImage tiffImage = (TiffImage)Image.Load(tempTiffPath))
            {
                // Deskew the image
                tiffImage.NormalizeAngle(false, Color.White);

                // Prepare PDF options with text rendering hint
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        BackgroundColor = Color.White,
                        PageWidth = tiffImage.Width,
                        PageHeight = tiffImage.Height
                    }
                };

                // Save the deskewed image to PDF
                tiffImage.Save(outputPath, pdfOptions);
            }

            // Cleanup temporary TIFF file
            if (File.Exists(tempTiffPath))
            {
                File.Delete(tempTiffPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}