using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input WebP and output PDF paths
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "test.webp");
        string outputPath = System.IO.Path.Combine(dir, "test.pdf");

        // Load the WebP image (uses the provided load rule)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save the image as PDF (no specific rule exists, so free‑form code is used)
            webPImage.Save(outputPath, new PdfOptions());
        }
    }
}