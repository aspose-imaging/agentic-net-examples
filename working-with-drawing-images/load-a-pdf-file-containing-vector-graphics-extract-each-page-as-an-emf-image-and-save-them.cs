using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PDF file path
            string inputPath = @"C:\Data\input.pdf";

            // Hardcoded output directory for EMF files
            string outputDir = @"C:\Data\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Try to treat the loaded image as a multipage image (PDF is multipage)
                var multipage = image as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                for (int i = 0; i < pageCount; i++)
                {
                    // Obtain the image representing the current page
                    Image pageImage;
                    if (multipage != null)
                    {
                        // Access the specific page from the multipage collection
                        pageImage = multipage.Pages[i];
                    }
                    else
                    {
                        // Single‑page fallback (should not happen for PDF)
                        pageImage = image;
                    }

                    using (pageImage)
                    {
                        // Prepare EMF save options with rasterization settings matching the page size
                        var emfOptions = new EmfOptions
                        {
                            VectorRasterizationOptions = new EmfRasterizationOptions
                            {
                                PageSize = pageImage.Size
                            }
                        };

                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as an EMF image
                        pageImage.Save(outputPath, emfOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}