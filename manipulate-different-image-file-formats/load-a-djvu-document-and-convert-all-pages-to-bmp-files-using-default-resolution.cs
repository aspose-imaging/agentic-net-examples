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
        string inputPath = @"c:\temp\sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory
        string outputDir = @"c:\temp\output\";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu document
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file name: sample.1.bmp, sample.2.bmp, etc.
                    string outputPath = Path.Combine(
                        outputDir,
                        $"{Path.GetFileNameWithoutExtension(inputPath)}.{page.PageNumber}.bmp");

                    // Ensure the directory for this file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP using default options
                    page.Save(outputPath, new BmpOptions());
                }
            }
        }
    }
}