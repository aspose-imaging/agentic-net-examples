using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output PDF file
        string outputPdf = @"C:\Images\combined.pdf";

        // Verify each input file exists
        foreach (var inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

        // List to hold WMF images
        List<Image> wmfImages = new List<Image>();

        // Convert each JPG to WMF and store in memory
        foreach (var jpgPath in inputFiles)
        {
            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare WMF rasterization options matching the source size
                var wmfRasterOptions = new WmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Save JPG as WMF into a memory stream
                using (var ms = new MemoryStream())
                {
                    jpgImage.Save(ms, new WmfOptions { VectorRasterizationOptions = wmfRasterOptions });
                    ms.Position = 0; // Reset stream for reading

                    // Load the WMF image from the memory stream
                    Image wmfImage = Image.Load(ms);
                    wmfImages.Add(wmfImage);
                }
            }
        }

        // Create a multipage image from the WMF images
        Image[] wmfArray = wmfImages.ToArray();
        using (Image pdfImage = Image.Create(wmfArray))
        {
            // Save the multipage image as a PDF document
            pdfImage.Save(outputPdf, new PdfOptions());
        }

        // Dispose all WMF images
        foreach (var img in wmfImages)
        {
            img.Dispose();
        }
    }
}