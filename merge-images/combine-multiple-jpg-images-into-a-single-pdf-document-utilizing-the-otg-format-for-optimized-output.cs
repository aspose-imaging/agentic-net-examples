using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded output PDF file
        string outputPath = @"C:\Images\combined.pdf";

        // Verify that every input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare PDF save options
            var pdfOptions = new PdfOptions();

            // Use OTG rasterization options for optimized PDF output
            var otgRasterOptions = new OtgRasterizationOptions();

            // Set page size based on the first image (optional but keeps original dimensions)
            using (Image firstImage = Image.Load(inputPaths[0]))
            {
                otgRasterOptions.PageSize = firstImage.Size;
            }

            // Optional: set a white background for consistency
            otgRasterOptions.BackgroundColor = Color.White;

            pdfOptions.VectorRasterizationOptions = otgRasterOptions;

            // Save the combined PDF
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}