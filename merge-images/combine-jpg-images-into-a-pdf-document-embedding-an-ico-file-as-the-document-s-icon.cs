using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files to be combined
        string[] jpgFiles = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output PDF file path
        string outputPdf = "combined.pdf";
        // ICO file to be used as document icon (embedding not directly supported)
        string icoFile = "icon.ico";

        // Load the ICO file (placeholder for potential embedding)
        using (Image icoImage = Image.Load(icoFile))
        {
            // ICO loaded – Aspose.Imaging does not provide a direct API to embed an icon into a PDF.
        }

        // Create a multipage image from the JPG files
        using (Image pdfImage = Image.Create(jpgFiles))
        {
            // Configure PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the combined images as a PDF document
            pdfImage.Save(outputPdf, pdfOptions);
        }
    }
}