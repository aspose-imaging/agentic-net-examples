using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input PDF path
        string inputPath = @"C:\Data\input.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for EMF files
        string outputDir = @"C:\Data\OutputEmf";

        // Ensure the output directory exists (unconditional per requirements)
        Directory.CreateDirectory(outputDir);

        // Load the PDF document
        using (Image pdfImage = Image.Load(inputPath))
        {
            // Cast to multipage interface to access individual pages
            IMultipageImage multipage = pdfImage as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The loaded file is not a multipage image.");
                return;
            }

            // Iterate through each page and save as EMF
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Retrieve the page image
                using (Image pageImage = multipage.Pages[i])
                {
                    // Construct output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure vector rasterization options based on the page size
                    var vectorOptions = new EmfRasterizationOptions
                    {
                        PageSize = pageImage.Size
                    };

                    // Set up EMF save options with the rasterization settings
                    var emfOptions = new EmfOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

                    // Save the page as an EMF file
                    pageImage.Save(outputPath, emfOptions);
                }
            }
        }
    }
}