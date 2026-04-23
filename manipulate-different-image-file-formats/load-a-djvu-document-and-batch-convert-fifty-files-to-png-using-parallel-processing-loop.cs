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
            // Hardcoded list of 50 DjVu files
            string[] inputFiles = new string[50];
            for (int i = 0; i < 50; i++)
            {
                inputFiles[i] = $@"C:\Djvu\Input\file{i + 1}.djvu";
            }

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output directory and ensure it exists
                string outputDir = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "Output");
                Directory.CreateDirectory(outputDir);

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu document
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // Iterate through pages and save each as PNG
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            string outputPath = Path.Combine(
                                outputDir,
                                $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.PageNumber}.png");

                            // Ensure directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
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