using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu files
        string[] inputFiles = new[]
        {
            @"C:\Images\Input\document1.djvu",
            @"C:\Images\Input\document2.djvu",
            @"C:\Images\Input\document3.djvu"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\Images\Output";

        // Process each DjVu file in parallel
        Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (unconditional)
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file name: originalname_page{PageNumber}.png
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{djvuPage.PageNumber}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the directory for the output file exists (unconditional)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        djvuPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        });
    }
}