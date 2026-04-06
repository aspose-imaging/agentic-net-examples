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
        string[] inputPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output PDF file
        string outputPdfPath = @"C:\Images\CombinedOutput.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Prepare list to hold WMF images
        List<Image> wmfImages = new List<Image>();

        foreach (string jpgPath in inputPaths)
        {
            // Define temporary WMF path (same folder, same name with .wmf extension)
            string wmfPath = Path.ChangeExtension(jpgPath, ".wmf");

            // Ensure output directory exists before saving WMF
            Directory.CreateDirectory(Path.GetDirectoryName(wmfPath));

            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Set up vector rasterization options matching the source image size
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Save as WMF
                jpgImage.Save(wmfPath, new WmfOptions { VectorRasterizationOptions = rasterOptions });
            }

            // Load the created WMF image and add to the collection
            Image wmfImage = Image.Load(wmfPath);
            wmfImages.Add(wmfImage);
        }

        // Create a multipage image from the WMF pages
        using (Image multipage = Image.Create(wmfImages.ToArray()))
        {
            // Ensure output directory exists before saving PDF
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Save the multipage image as a PDF document
            multipage.Save(outputPdfPath, new PdfOptions());
        }

        // Dispose WMF images that were loaded separately
        foreach (var img in wmfImages)
        {
            img.Dispose();
        }
    }
}