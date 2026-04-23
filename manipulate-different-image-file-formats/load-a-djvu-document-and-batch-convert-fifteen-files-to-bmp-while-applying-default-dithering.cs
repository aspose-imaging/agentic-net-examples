using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and output directory
            string inputDir = @"C:\Input";
            string outputDir = @"C:\Output";

            // List of fifteen DjVu files to process
            string[] inputFiles = new string[]
            {
                "file1.djvu", "file2.djvu", "file3.djvu", "file4.djvu", "file5.djvu",
                "file6.djvu", "file7.djvu", "file8.djvu", "file9.djvu", "file10.djvu",
                "file11.djvu", "file12.djvu", "file13.djvu", "file14.djvu", "file15.djvu"
            };

            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = Path.Combine(inputDir, inputFiles[i]);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu document
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                {
                    // Apply default dithering (Floyd‑Steinberg, 8‑bit palette)
                    djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                    // Save each page as a separate BMP file
                    int pageIndex = 0;
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        string outputPath = Path.Combine(outputDir,
                            $"output_{i + 1}_page{pageIndex}.bmp");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as BMP
                        page.Save(outputPath, new BmpOptions());

                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}