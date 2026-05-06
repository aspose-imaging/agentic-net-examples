using System;
using System.IO;
using System.Linq;
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\DjvuInput";
            string outputFolder = @"C:\PngOutput";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputFolder);

            // Prepare a list of 50 DjVu file paths (file1.djvu … file50.djvu)
            var inputFiles = Enumerable.Range(1, 50)
                .Select(i => Path.Combine(inputFolder, $"file{i}.djvu"))
                .ToList();

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file and load it
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Convert each page to PNG
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build the output PNG file name
                        string outputPath = Path.Combine(
                            outputFolder,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.PageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
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