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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputDjvu\";
            string outputDir = @"C:\OutputBmp\";

            // List of fifteen DjVu files to process
            string[] inputFiles = new string[]
            {
                "file1.djvu", "file2.djvu", "file3.djvu", "file4.djvu", "file5.djvu",
                "file6.djvu", "file7.djvu", "file8.djvu", "file9.djvu", "file10.djvu",
                "file11.djvu", "file12.djvu", "file13.djvu", "file14.djvu", "file15.djvu"
            };

            foreach (var fileName in inputFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDir);

                // Load the DjVu document
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Apply default dithering (Floyd‑Steinberg, 8‑bit palette)
                    djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                    // Save each page as a separate BMP file
                    int pageIndex = 0;
                    foreach (var page in djvuImage.Pages)
                    {
                        string pageOutputPath = Path.Combine(
                            outputDir,
                            $"{Path.GetFileNameWithoutExtension(fileName)}_page{pageIndex}.bmp");

                        // Ensure the directory for the page output exists
                        Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));

                        // Save the page using BMP options
                        page.Save(pageOutputPath, new BmpOptions());
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