using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Define page range (5‑10 inclusive)
            int startPage = 5;
            int endPage = 10;

            // Process each page in parallel
            Parallel.For(startPage, endPage + 1, pageNumber =>
            {
                // Build output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document inside the parallel task
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // DjVu pages are zero‑based; adjust index
                        int pageIndex = pageNumber - 1;

                        // Guard against invalid page index
                        if (pageIndex < 0 || pageIndex >= djvuImage.PageCount)
                        {
                            Console.Error.WriteLine($"Page {pageNumber} is out of range.");
                            return;
                        }

                        // Retrieve the specific page
                        using (Image pageImage = djvuImage.Pages[pageIndex])
                        {
                            // Configure TIFF save options
                            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                            tiffOptions.Compression = TiffCompressions.Deflate;

                            // Save the page as a TIFF file
                            pageImage.Save(outputPath, tiffOptions);
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}