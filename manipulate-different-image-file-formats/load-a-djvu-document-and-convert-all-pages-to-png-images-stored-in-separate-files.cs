using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"C:\temp\sample.djvu";
            // Hardcoded output directory
            string outputDir = @"C:\temp\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file name based on page number
                        string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a PNG image
                        djvuPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}