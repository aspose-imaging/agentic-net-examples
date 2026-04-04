using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths.
        string inputPath = @"c:\temp\test.emf";
        string outputPath = @"c:\temp\test.output.pdf";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image.
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Configure EMF rasterization options.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Keep the original page size.
                PageSize = emfImage.Size,

                // Apply anti‑aliasing to improve rendering quality.
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,

                // Use automatic render mode.
                RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
            };

            // Set up PDF save options and attach the rasterization options.
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the EMF as a PDF. Text will be rendered as vector shapes because
            // we are using vector rasterization options.
            emfImage.Save(outputPath, pdfOptions);
        }
    }
}