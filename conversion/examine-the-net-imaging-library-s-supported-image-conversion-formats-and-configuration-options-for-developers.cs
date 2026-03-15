using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (replace with an actual file path)
        string inputPath = "input.jpg";

        // Output directory (ensure it exists)
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Save as BMP using default options
            string bmpPath = Path.Combine(outputDir, "output.bmp");
            image.Save(bmpPath, new BmpOptions());

            // Save as JPEG using default options
            string jpegPath = Path.Combine(outputDir, "output.jpg");
            image.Save(jpegPath, new JpegOptions());

            // Save as PNG using default options
            string pngPath = Path.Combine(outputDir, "output.png");
            image.Save(pngPath, new PngOptions());

            // Save as TIFF using default options (specify expected format)
            string tiffPath = Path.Combine(outputDir, "output.tif");
            image.Save(tiffPath, new TiffOptions(TiffExpectedFormat.Default));

            // Save as PDF using default options
            string pdfPath = Path.Combine(outputDir, "output.pdf");
            var pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo()
            };
            image.Save(pdfPath, pdfOptions);
        }
    }
}