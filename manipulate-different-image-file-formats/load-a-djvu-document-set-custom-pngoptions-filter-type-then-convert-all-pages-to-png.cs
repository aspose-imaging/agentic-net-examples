using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Prepare PNG options with custom filter type
            PngOptions pngOptions = new PngOptions
            {
                FilterType = PngFilterType.Sub
            };

            // Convert each page to PNG
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG using the custom options
                djvuPage.Save(outputPath, pngOptions);
            }
        }
    }
}