using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files
        string[] jpegPaths = { "input1.jpg", "input2.jpg" };

        // List to hold loaded EPS images
        List<Image> epsImages = new List<Image>();

        foreach (string jpegPath in jpegPaths)
        {
            // Verify JPEG input exists
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }

            // Determine EPS output path
            string epsPath = Path.ChangeExtension(jpegPath, ".eps");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(epsPath));

            // Load JPEG and save as EPS (default options)
            using (Image jpegImage = Image.Load(jpegPath))
            {
                jpegImage.Save(epsPath);
            }

            // Verify EPS was created
            if (!File.Exists(epsPath))
            {
                Console.Error.WriteLine($"Failed to create EPS: {epsPath}");
                return;
            }

            // Load EPS image and keep it for PDF merging
            Image epsImage = Image.Load(epsPath);
            epsImages.Add(epsImage);
        }

        if (epsImages.Count == 0)
        {
            Console.Error.WriteLine("No EPS images to combine.");
            return;
        }

        // Create a multipage image (PDF) from the EPS images
        using (Image pdfDocument = Image.Create(epsImages.ToArray(), true))
        {
            string pdfPath = "combined.pdf";

            // Ensure PDF output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Save the combined PDF
            PdfOptions pdfOptions = new PdfOptions();
            pdfDocument.Save(pdfPath, pdfOptions);
        }

        // Dispose all loaded EPS images
        foreach (var img in epsImages)
        {
            img.Dispose();
        }
    }
}