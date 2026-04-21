using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"C:\temp\sample.djvu";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory
        string outputDir = @"C:\temp\output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu image from the stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page in the DjVu document
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Build the output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                    // Ensure the directory for the output file exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as a PNG image
                    djvuPage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}