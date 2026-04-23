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
        try
        {
            // Hardcoded input DjVu files
            string[] inputFiles = new[]
            {
                @"C:\Input\sample1.djvu",
                @"C:\Input\sample2.djvu"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Output";

            // Process each DjVu file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists (creates if missing)
                Directory.CreateDirectory(outputDirectory);

                // Open the DjVu file stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu image from stream
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // Iterate through each page
                        foreach (DjvuPage djvuPage in djvuImage.Pages)
                        {
                            // Build output file name: <originalname>_page<Number>.png
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{djvuPage.PageNumber}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            djvuPage.Save(outputPath, new PngOptions());
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}