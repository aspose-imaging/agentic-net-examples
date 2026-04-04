using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PDF path
        string inputPath = "Input\\maps.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the PDF document
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the loaded image supports multiple pages
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The input file is not a multipage vector image.");
                return;
            }

            // Prepare output directory
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Iterate through each page of the PDF
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Define output TIFF path for the current page
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");

                // Ensure the output directory exists (guard against null)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Set up vector rasterization to render the PDF page at high resolution
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                tiffOptions.VectorRasterizationOptions = vectorOptions;

                // Export only the current page as a single-page TIFF
                tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                // Save the page to TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}