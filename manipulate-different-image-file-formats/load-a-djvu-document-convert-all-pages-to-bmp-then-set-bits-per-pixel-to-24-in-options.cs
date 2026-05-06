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
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputDirectory = @"C:\Temp\DjvuToBmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (CreateDirectory works even if the directory already exists)
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set BMP save options with 24 bits per pixel
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 24
                        };

                        // Save the page as BMP
                        page.Save(outputPath, bmpOptions);
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