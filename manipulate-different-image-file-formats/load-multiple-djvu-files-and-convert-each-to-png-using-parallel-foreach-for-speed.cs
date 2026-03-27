using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

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
        string outputDir = @"C:\Images\Output";

        // Process each DjVu file in parallel
        Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file name: <originalFileName>_page<Number>.png
                        string inputFileName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputFileName = $"{inputFileName}_page{page.PageNumber}.png";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
                    }
                }
            }
        });
    }
}