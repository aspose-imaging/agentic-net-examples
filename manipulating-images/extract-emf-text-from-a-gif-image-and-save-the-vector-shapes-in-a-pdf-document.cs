using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string emfPath = @"C:\Images\output.emf";
        string pdfPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(emfPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Load the GIF image
        using (Image gifImage = Image.Load(inputPath))
        {
            // Convert the GIF to EMF (vector) – this rasterizes the image into an EMF container
            var emfRasterOptions = new EmfRasterizationOptions
            {
                PageSize = gifImage.Size,
                BackgroundColor = Color.White,
                RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
            };

            var emfSaveOptions = new EmfOptions
            {
                VectorRasterizationOptions = emfRasterOptions
            };

            gifImage.Save(emfPath, emfSaveOptions);
        }

        // Load the generated EMF to extract its vector representation
        using (EmfImage emfImage = (EmfImage)Image.Load(emfPath))
        {
            // Prepare PDF save options with vector rasterization (preserves vector shapes)
            var pdfRasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White,
                RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
            };

            var pdfSaveOptions = new PdfOptions
            {
                VectorRasterizationOptions = pdfRasterOptions
            };

            // Save the EMF content as a PDF document
            emfImage.Save(pdfPath, pdfSaveOptions);
        }
    }
}