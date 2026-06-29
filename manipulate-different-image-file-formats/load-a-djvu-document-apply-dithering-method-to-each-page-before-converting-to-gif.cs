using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (DjvuPage page in djvu.Pages)
                {
                    using (page)
                    {
                        // Apply Floyd‑Steinberg dithering with 1‑bit palette
                        page.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                        // Prepare output path for this page
                        string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.gif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the dithered page as GIF
                        GifOptions gifOptions = new GifOptions();
                        page.Save(outputPath, gifOptions);
                    }

                    pageIndex++;
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
 * 1. When a developer must extract each page of a multi‑page DjVu file and create high‑contrast 1‑bit GIF images using Floyd‑Steinberg dithering for web‑ready preview thumbnails.
 * 2. When a C# application needs to batch‑process scanned DjVu archives, apply binary dithering to improve readability, and save the results as GIF files for legacy systems that only support GIF.
 * 3. When an image‑processing pipeline requires converting DjVu pages to GIF format while reducing color depth to a single bit to minimize file size for email attachments.
 * 4. When a document‑management solution has to generate GIF previews of DjVu pages with consistent dithering to ensure uniform visual quality across all pages.
 * 5. When a developer wants to automate the conversion of DjVu e‑books into GIF slideshows, applying Floyd‑Steinberg dithering to each page to preserve detail in monochrome displays.
 */