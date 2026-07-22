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
            string inputPath = "input\\sample.djvu";

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

                // Process pages 1‑3 (indices 0‑2)
                for (int i = 0; i < 3 && i < djvuImage.PageCount; i++)
                {
                    DjvuPage page = (DjvuPage)djvuImage.Pages[i];

                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1);

                    // Define output BMP path
                    string outputPath = $"output\\page{i + 1}.bmp";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP
                    page.Save(outputPath, new BmpOptions());
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
 * 1. When a document management system needs to extract the first three pages of a DjVu file and store them as high‑contrast BMP images for archival or OCR processing, this code can automate the conversion and apply Floyd‑Steinberg dithering to preserve detail.
 * 2. When a web application must generate thumbnail previews of DjVu pages in a 1‑bit bitmap format for fast loading on low‑bandwidth devices, the snippet loads the DjVu, dithers each page, and saves them as BMP files.
 * 3. When a printing workflow requires converting selected DjVu pages to BMP with binary color depth to meet legacy printer specifications, the code performs the page extraction, Floyd‑Steinberg dithering, and BMP output in C#.
 * 4. When a digital forensics tool needs to create exact visual replicas of the first three pages of a DjVu document while reducing file size using 1‑bit dithering, this example demonstrates the necessary Aspose.Imaging operations.
 * 5. When a batch‑processing script must programmatically read a DjVu file, apply Floyd‑Steinberg dithering to enhance edge definition, and save the result as BMP images for further analysis, the provided code fulfills that requirement.
 */