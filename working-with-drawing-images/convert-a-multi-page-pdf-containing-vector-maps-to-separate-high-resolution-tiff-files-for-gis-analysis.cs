using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input PDF path (hard‑coded)
        string inputPath = "Input\\maps.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output directory (hard‑coded)
        string outputDirectory = "Output";

        // Ensure output directory exists
        if (!string.IsNullOrWhiteSpace(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Load the PDF document
        using (Image pdfImage = Image.Load(inputPath))
        {
            // Cast to multipage interface
            IMultipageImage multipage = pdfImage as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The input file is not a multipage vector image.");
                return;
            }

            int pageCount = multipage.PageCount;

            // Export each page to a separate high‑resolution TIFF
            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                // Ensure the directory for this file exists
                string outDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Vector rasterization for high‑resolution output
                tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = pdfImage.Width,
                    PageHeight = pdfImage.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Export only the current page
                tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                // Save the page as TIFF
                pdfImage.Save(outputPath, tiffOptions);
            }
        }
    }
}