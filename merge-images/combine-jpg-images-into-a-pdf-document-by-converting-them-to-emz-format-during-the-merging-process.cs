using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] jpgFiles =
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // List to hold paths of intermediate EMZ files
        List<string> emzFiles = new List<string>();

        foreach (string jpgPath in jpgFiles)
        {
            // Verify input file exists
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }

            // Determine EMZ output path (same folder, .emz extension)
            string emzPath = Path.ChangeExtension(jpgPath, ".emz");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(emzPath));

            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare vector rasterization options matching the source image size
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Save as compressed EMF (EMZ) format
                jpgImage.Save(emzPath, new EmfOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    Compress = true
                });
            }

            emzFiles.Add(emzPath);
        }

        // Verify we have at least one EMZ file to merge
        if (emzFiles.Count == 0)
        {
            Console.Error.WriteLine("No images were processed.");
            return;
        }

        // Create a multipage image from the EMZ files
        using (Image multipage = Image.Create(emzFiles.ToArray()))
        {
            // Define output PDF path
            string outputPdf = @"C:\Output\CombinedImages.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

            // Save the multipage image as a PDF document
            multipage.Save(outputPdf, new PdfOptions());
        }
    }
}