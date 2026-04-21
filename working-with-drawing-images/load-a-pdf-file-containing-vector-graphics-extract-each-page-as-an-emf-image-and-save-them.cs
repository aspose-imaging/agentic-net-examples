using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input PDF file path
        string inputPath = @"C:\Input\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for EMF files
        string outputDir = @"C:\Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the PDF document
        using (Image pdfImage = Image.Load(inputPath))
        {
            // Cast to multipage image to get page count
            IMultipageImage multipage = pdfImage as IMultipageImage;
            if (multipage == null || multipage.PageCount == 0)
            {
                Console.Error.WriteLine("The loaded document does not contain any pages.");
                return;
            }

            // Iterate over each page and save as EMF
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Prepare output file path for the current page
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                // Ensure the directory for the output file exists (redundant but follows the rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up EMF export options for the current page
                EmfOptions exportOptions = new EmfOptions();

                // Export only the current page
                exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                // Configure vector rasterization options (page size)
                exportOptions.VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = pdfImage.Size
                };

                // Save the current page as EMF
                pdfImage.Save(outputPath, exportOptions);
            }
        }
    }
}