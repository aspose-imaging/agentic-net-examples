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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory
        string outputDir = @"C:\temp\output";

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu document
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page in the document
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Build output file name: sample.1.bmp, sample.2.bmp, etc.
                    string fileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.{djvuPage.PageNumber}.bmp";
                    string outputPath = Path.Combine(outputDir, fileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP using default resolution
                    djvuPage.Save(outputPath, new BmpOptions());
                }
            }
        }
    }
}