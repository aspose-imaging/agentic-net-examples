using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Guard against empty documents
            if (cdrImage.PageCount == 0)
            {
                Console.Error.WriteLine("The CDR file contains no pages.");
                return;
            }

            // Get the first (single) page
            CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

            // Configure rasterization to preserve transparency
            var rasterOptions = new CdrRasterizationOptions
            {
                BackgroundColor = Color.Transparent,   // keep transparent background
                PageWidth = page.Width,
                PageHeight = page.Height
            };

            // PNG save options using the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the page as PNG
            page.Save(outputPath, pngOptions);
        }
    }
}