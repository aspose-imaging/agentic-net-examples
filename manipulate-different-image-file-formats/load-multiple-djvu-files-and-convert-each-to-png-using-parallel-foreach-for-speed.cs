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
        string[] inputFiles = new string[]
        {
            @"C:\DjvuFiles\doc1.djvu",
            @"C:\DjvuFiles\doc2.djvu"
        };

        // Hardcoded root output directory
        string outputRoot = @"C:\PngOutput";

        try
        {
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Create a subdirectory for each DjVu file's pages
                string fileBaseName = Path.GetFileNameWithoutExtension(inputPath);
                string outputDir = Path.Combine(outputRoot, fileBaseName);
                Directory.CreateDirectory(outputDir);

                // Open the DjVu file stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Load the DjVu document using the provided LoadDocument method
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
                        // Iterate through each page and save as PNG
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.png");
                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            // Save the page as PNG using the provided Save method
                            page.Save(outputPath, new PngOptions());
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