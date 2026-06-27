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
            // Hard‑coded input path
            string inputPath = "C:\\temp\\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DjVu document
            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvuImage = (DjvuImage)image;

                // Iterate over all pages and process pages 1‑3
                foreach (var page in djvuImage.Pages)
                {
                    if (page is DjvuPage djvuPage && djvuPage.PageNumber >= 1 && djvuPage.PageNumber <= 3)
                    {
                        // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                        djvuPage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                        // Construct output path for the BMP file
                        string outputPath = $"C:\\temp\\output_page{djvuPage.PageNumber}.bmp";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed page as BMP
                        djvuPage.Save(outputPath, new BmpOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract the first three pages of a multi‑page DjVu document and generate high‑contrast 1‑bit BMP images for a legacy printing workflow.
 * 2. When an application must convert scanned DjVu files to BMP format while applying Floyd‑Steinberg dithering to preserve visual detail on monochrome displays.
 * 3. When a digital archiving system requires batch processing of DjVu files to produce BMP thumbnails of the initial pages for quick preview in a web portal.
 * 4. When a developer is building a document‑to‑e‑ink pipeline that needs 1‑bit BMP output with error‑diffusion dithering from DjVu source pages.
 * 5. When a Windows desktop utility must verify the existence of a DjVu file, extract pages 1‑3, and save them as BMP files with Floyd‑Steinberg dithering for downstream OCR processing.
 */