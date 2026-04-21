using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.djvu";
        string outputDirectory = "Output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (will be used for all pages)
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Configure PNG options with a custom filter type
            PngOptions pngOptions = new PngOptions
            {
                FilterType = PngFilterType.Sub // Example filter type
            };

            // Iterate through each page and save as PNG
            foreach (Image page in djvuImage.Pages)
            {
                using (page)
                {
                    // Cast to DjvuPage to obtain page number
                    DjvuPage djvuPage = (DjvuPage)page;
                    int pageNumber = djvuPage.PageNumber;

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG using the configured options
                    djvuPage.Save(outputPath, pngOptions);
                }
            }
        }
    }
}