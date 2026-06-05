using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\sample.cdr";
            string outputPath = @"C:\Temp\sample.psd";

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
                // Access the first (and only) page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                // Prepare PSD save options with vector rasterization settings
                PsdOptions psdOptions = new PsdOptions();

                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };

                psdOptions.VectorRasterizationOptions = rasterOptions;

                // Save the page as a PSD file, preserving layers
                page.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}