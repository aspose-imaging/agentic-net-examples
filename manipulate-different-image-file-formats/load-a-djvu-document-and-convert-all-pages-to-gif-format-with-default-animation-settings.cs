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
        string inputPath = "sample.djvu";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file as a stream
        using (Stream inputStream = File.OpenRead(inputPath))
        {
            // Load the DjVu document from the stream
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
            {
                // Iterate through each page in the DjVu document
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Build the output GIF file path for the current page
                    string outputPath = Path.Combine("output", $"page{djvuPage.PageNumber}.gif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a GIF image using default options
                    djvuPage.Save(outputPath, new GifOptions());
                }
            }
        }
    }
}