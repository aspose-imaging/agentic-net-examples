using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded base directories for input DjVu files and output PNG files
        string inputBaseDir = @"C:\DjvuInput";
        string outputBaseDir = @"C:\PngOutput";

        // Process 50 DjVu files named file1.djvu ... file50.djvu
        Parallel.For(0, 50, i =>
        {
            // Build input and output paths
            string inputPath = Path.Combine(inputBaseDir, $"file{i + 1}.djvu");
            string outputDir = Path.Combine(outputBaseDir, $"file{i + 1}");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file stream and load the document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int pageNumber = 1;
                foreach (var djvuPage in djvuImage.Pages)
                {
                    // Build the output PNG file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page{pageNumber}.png");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());

                    pageNumber++;
                }
            }
        });
    }
}