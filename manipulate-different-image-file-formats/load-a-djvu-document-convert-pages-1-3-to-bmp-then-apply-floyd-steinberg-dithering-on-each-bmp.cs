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
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DjVu document
            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvuImage = image as DjvuImage;
                if (djvuImage == null)
                {
                    Console.Error.WriteLine("Failed to load DjVu image.");
                    return;
                }

                // Process up to the first three pages
                int pagesToProcess = Math.Min(3, djvuImage.PageCount);
                for (int i = 0; i < pagesToProcess; i++)
                {
                    // Retrieve the page
                    var djvuPage = djvuImage.Pages[i] as DjvuPage;
                    if (djvuPage == null)
                        continue;

                    // Apply Floyd‑Steinberg dithering (1‑bit palette)
                    djvuPage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Define output BMP path
                    string outputPath = $@"C:\temp\output_page{i + 1}.bmp";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP
                    djvuPage.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract the first three pages of a DjVu document and save them as BMP files for compatibility with legacy Windows applications.
 * 2. When a developer wants to convert DjVu pages to 1‑bit monochrome BMP images using Floyd‑Steinberg dithering to reduce file size while preserving visual detail.
 * 3. When a developer must batch‑process scanned DjVu archives and generate printable BMP outputs for archival or OCR pipelines.
 * 4. When a developer requires a C# routine that validates the input DjVu file, handles missing pages, and creates the necessary output directories before saving images.
 * 5. When a developer is building a .NET utility that applies error‑diffusion dithering to DjVu pages before converting them to BMP for use in low‑color‑depth devices or embedded systems.
 */