using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputJpgPath = @"C:\Images\input.jpg";
        string tempGifPath = @"C:\Images\temp.gif";
        string outputPdfPath = @"C:\Images\output.pdf";

        // Verify input JPG exists
        if (!File.Exists(inputJpgPath))
        {
            Console.Error.WriteLine($"File not found: {inputJpgPath}");
            return;
        }

        // Ensure directories exist for temporary GIF and final PDF
        Directory.CreateDirectory(Path.GetDirectoryName(tempGifPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the JPEG image
        using (Image jpegImage = Image.Load(inputJpgPath))
        {
            // Convert and save as GIF
            jpegImage.Save(tempGifPath, new GifOptions());
        }

        // Load the generated GIF image
        using (Image gifImage = Image.Load(tempGifPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions();

            // Save the GIF (single page) as a PDF document
            gifImage.Save(outputPdfPath, pdfOptions);
        }
    }
}