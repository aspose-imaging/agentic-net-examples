using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] jpgPaths = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Temporary folder for intermediate EMF files
        string tempEmfFolder = @"C:\Temp\Emf";
        Directory.CreateDirectory(tempEmfFolder);

        var emfPaths = new List<string>();

        // Convert each JPG to EMF preserving vector fidelity
        foreach (string jpgPath in jpgPaths)
        {
            // Input file existence check (no exceptions)
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }

            string emfPath = Path.Combine(
                tempEmfFolder,
                Path.GetFileNameWithoutExtension(jpgPath) + ".emf");

            // Load JPG, set up EMF rasterization options, and save as EMF
            using (Image jpgImage = Image.Load(jpgPath))
            {
                var emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                var emfSaveOptions = new EmfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };

                // Ensure output directory exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(emfPath));
                jpgImage.Save(emfPath, emfSaveOptions);
            }

            emfPaths.Add(emfPath);
        }

        // Create a multipage image from the generated EMF files
        using (Image multipageEmf = Image.Create(emfPaths.ToArray()))
        {
            // Hard‑coded PDF output path
            string outputPdfPath = @"C:\Output\CombinedImages.pdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Save the multipage image as a PDF document
            var pdfOptions = new PdfOptions();
            multipageEmf.Save(outputPdfPath, pdfOptions);
        }
    }
}