using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.djvu";
        string outputDirectory = "Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (will be created for each file as well)
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Prepare PNG options with custom filter type
            PngOptions pngOptions = new PngOptions
            {
                FilterType = PngFilterType.Sub
            };

            // Iterate through each page and save as PNG
            foreach (DjvuPage page in djvuImage.Pages)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG using the specified options
                page.Save(outputPath, pngOptions);
            }
        }
    }
}