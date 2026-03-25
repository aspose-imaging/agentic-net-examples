using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative to the executable location)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all CDR files in the input directory
        string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

        foreach (string cdrFile in cdrFiles)
        {
            // Verify the input file exists
            if (!File.Exists(cdrFile))
            {
                Console.Error.WriteLine($"File not found: {cdrFile}");
                continue;
            }

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(cdrFile))
            {
                // Cache the whole document to avoid repeated loading
                cdrImage.CacheData();

                int pageIndex = 0;
                foreach (var pageObj in cdrImage.Pages)
                {
                    // Each page is a CdrImagePage
                    var page = (CdrImagePage)pageObj;
                    page.CacheData();

                    // Build the output PNG file path
                    string baseName = Path.GetFileNameWithoutExtension(cdrFile);
                    string outputPath = Path.Combine(outputDirectory, $"{baseName}_page{pageIndex}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG export with vector rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        }
                    };

                    // Save the current page as PNG
                    page.Save(outputPath, pngOptions);

                    pageIndex++;
                }
            }
        }
    }
}