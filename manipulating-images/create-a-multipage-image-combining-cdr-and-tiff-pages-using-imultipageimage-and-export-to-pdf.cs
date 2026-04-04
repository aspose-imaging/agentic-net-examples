using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string cdrPath = "Input/sample.cdr";
        string tiffPath = "Input/sample.tif";
        string outputPath = "Output/combined.pdf";

        // Validate input files
        if (!File.Exists(cdrPath))
        {
            Console.Error.WriteLine($"File not found: {cdrPath}");
            return;
        }
        if (!File.Exists(tiffPath))
        {
            Console.Error.WriteLine($"File not found: {tiffPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source images
        using (Image cdrImage = Image.Load(cdrPath))
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Combine into a multipage image
            Image[] sourceImages = new Image[] { cdrImage, tiffImage };
            using (Image multipage = Image.Create(sourceImages))
            {
                // Prepare PDF export options with rasterization for vector pages
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = multipage.Width,
                        PageHeight = multipage.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save combined multipage image as PDF
                multipage.Save(outputPath, pdfOptions);
            }
        }
    }
}