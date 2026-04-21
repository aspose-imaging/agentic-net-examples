using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input SVG path
        string inputPath = "input.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for EMF files
        string outputDir = "output";

        // Ensure output directory exists (unconditional as per safety rule)
        Directory.CreateDirectory(outputDir);

        // Load the SVG image (supports multipage vector images)
        using (Image image = Image.Load(inputPath))
        {
            // Determine if the image supports multiple pages
            IMultipageImage multipage = image as IMultipageImage;
            int pageCount = (multipage != null) ? multipage.PageCount : 1;

            // Iterate through each page and save as separate EMF file
            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                // Configure EMF export options
                EmfOptions exportOptions = new EmfOptions
                {
                    // Export only the current page (EMF is single-page)
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1)),
                    // Set rasterization options based on the source image size
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the current page as EMF
                image.Save(outputPath, exportOptions);
            }
        }
    }
}