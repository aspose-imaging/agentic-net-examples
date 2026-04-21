using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Set load options to limit memory usage (e.g., 1 MB buffer)
        LoadOptions loadOptions = new LoadOptions
        {
            BufferSizeHint = 1 * 1024 * 1024 // 1 MB
        };

        // Open the DjVu file with memory‑optimized loading
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
        {
            // Iterate through pages and save pages 3‑7 as GIF files
            foreach (DjvuPage page in djvuImage.Pages)
            {
                int pageNumber = page.PageNumber;
                if (pageNumber >= 3 && pageNumber <= 7)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page{pageNumber}.gif");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as GIF
                    page.Save(outputPath, new GifOptions());
                }
            }
        }
    }
}