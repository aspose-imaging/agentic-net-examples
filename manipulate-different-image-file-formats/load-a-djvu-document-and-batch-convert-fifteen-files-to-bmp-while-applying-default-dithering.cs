using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input files (15 DjVu documents)
        string[] inputFiles = new string[]
        {
            "doc1.djvu", "doc2.djvu", "doc3.djvu", "doc4.djvu", "doc5.djvu",
            "doc6.djvu", "doc7.djvu", "doc8.djvu", "doc9.djvu", "doc10.djvu",
            "doc11.djvu", "doc12.djvu", "doc13.djvu", "doc14.djvu", "doc15.djvu"
        };

        // Base directories (hardcoded)
        string inputBaseDir = @"C:\InputDjvu";
        string outputBaseDir = @"C:\OutputBmp";

        for (int i = 0; i < inputFiles.Length; i++)
        {
            string inputPath = Path.Combine(inputBaseDir, inputFiles[i]);

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Apply default dithering (Floyd‑Steinberg, 8‑bit palette)
                djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Convert each page to BMP
                for (int pageIndex = 0; pageIndex < djvuImage.Pages.Length; pageIndex++)
                {
                    // Ensure output directory exists
                    string outputFileName = $"doc{i + 1}_page{pageIndex}.bmp";
                    string outputPath = Path.Combine(outputBaseDir, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save page as BMP
                    using (Image page = djvuImage.Pages[pageIndex])
                    {
                        page.Save(outputPath, new BmpOptions());
                    }
                }
            }
        }
    }
}