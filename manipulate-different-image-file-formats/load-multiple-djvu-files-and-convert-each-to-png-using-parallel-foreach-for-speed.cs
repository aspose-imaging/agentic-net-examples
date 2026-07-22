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
                @"C:\Input\document1.djvu",
                @"C:\Input\document2.djvu",
                @"C:\Input\document3.djvu"
            };

            // Output directory for PNG files
            string outputDir = @"C:\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Process each DjVu file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu image
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // Iterate through pages
                        foreach (DjvuPage djvuPage in djvuImage.Pages)
                        {
                            // Build output file name: original name + page number
                            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                            string outputFileName = $"{fileNameWithoutExt}.{djvuPage.PageNumber}.png";
                            string outputPath = Path.Combine(outputDir, outputFileName);

                            // Ensure directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save page as PNG
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

/*
 * Real-World Use Cases:
 * 1. When a digital archive needs to batch‑convert scanned DjVu documents into PNG thumbnails for web preview, a developer can use this parallel conversion code to speed up processing.
 * 2. When an e‑learning platform receives lecture notes in DjVu format and must generate PNG images for each page to embed in HTML lessons, the code enables fast multi‑file conversion.
 * 3. When a legal firm digitizes case files stored as DjVu and wants to create PNG copies for OCR pipelines, the parallel loop reduces the time required to prepare many files.
 * 4. When a publishing house prepares print‑ready assets and needs to extract each page of multiple DjVu manuscripts as high‑resolution PNGs for layout software, this code automates the task efficiently.
 * 5. When a cloud‑based document‑management service offers on‑demand image previews and must convert several DjVu uploads to PNG simultaneously, the Parallel.ForEach approach ensures responsive performance.
 */