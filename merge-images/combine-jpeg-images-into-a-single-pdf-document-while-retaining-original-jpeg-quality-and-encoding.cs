using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input folder containing JPEG files and output PDF path
        string inputFolder = args.Length > 0 ? args[0] : "InputJpegs";
        string outputPdfPath = args.Length > 1 ? args[1] : "Combined.pdf";

        // Collect JPEG file paths
        string[] jpegFiles = Directory.GetFiles(inputFolder, "*.jpg");
        var loadedImages = new List<Image>();

        // Load each JPEG image
        foreach (string filePath in jpegFiles)
        {
            Image img = Image.Load(filePath);
            loadedImages.Add(img);
        }

        // Create a multipage image (PDF) from the loaded JPEG images
        using (Image pdfDocument = Image.Create(loadedImages.ToArray()))
        {
            PdfOptions pdfOptions = new PdfOptions
            {
                KeepMetadata = true,
                UseOriginalImageResolution = true
            };

            pdfDocument.Save(outputPdfPath, pdfOptions);
        }

        // Dispose the individual JPEG images
        foreach (Image img in loadedImages)
        {
            img.Dispose();
        }
    }
}