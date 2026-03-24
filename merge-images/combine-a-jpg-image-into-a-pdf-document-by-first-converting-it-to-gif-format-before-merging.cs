using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputJpgPath = @"C:\temp\input.jpg";
        string tempGifPath = @"C:\temp\temp.gif";
        string outputPdfPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputJpgPath))
        {
            Console.Error.WriteLine($"File not found: {inputJpgPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the JPEG image
        using (Image jpgImage = Image.Load(inputJpgPath))
        {
            // Convert and save as GIF
            jpgImage.Save(tempGifPath);
        }

        // Create a multipage image from the GIF (single page in this case)
        using (Image gifMultipage = Image.Create(new string[] { tempGifPath }))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            gifMultipage.Save(outputPdfPath, pdfOptions);
        }
    }
}