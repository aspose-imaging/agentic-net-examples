using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PDF and output directory
            string inputPath = @"C:\Data\maps.pdf";
            string outputDir = @"C:\Data\MapsSvg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Cast to multipage interface to get page count
                IMultipageImage multipage = pdfImage as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1; // Fallback to 1 if not multipage

                for (int i = 0; i < pageCount; i++)
                {
                    // Build output file path for each page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.svg");

                    // Ensure directory for the output file exists (covers nested paths)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare SVG save options
                    SvgOptions svgOptions = new SvgOptions
                    {
                        KeepMetadata = true,               // Preserve geographic metadata
                        TextAsShapes = true                // Render text as shapes (optional)
                    };

                    // Set vector rasterization options based on the source image
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageSize = pdfImage.Size,          // Preserve original page size
                        BackgroundColor = Color.White      // Optional background
                    };
                    svgOptions.VectorRasterizationOptions = vectorOptions;

                    // Export only the current page
                    svgOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    // Save the page as SVG
                    pdfImage.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}