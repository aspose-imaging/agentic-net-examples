using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "input.djvu";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for BMP files
            string outputDir = "output";
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int pageIndex = 0;
                foreach (Image page in djvuImage.Pages)
                {
                    // Construct output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (page)
                    {
                        // Configure BMP options
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 32
                        };

                        // Save the page as BMP
                        page.Save(outputPath, bmpOptions);
                    }

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}