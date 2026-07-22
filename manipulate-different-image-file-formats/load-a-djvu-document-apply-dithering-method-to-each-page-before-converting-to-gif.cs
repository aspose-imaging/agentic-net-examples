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
            string outputDir = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Apply dithering to the page
                    page.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Prepare output path for the GIF page
                    string outputPath = Path.Combine(outputDir, $"page{pageIndex}.gif");

                    // Save the dithered page as GIF
                    page.Save(outputPath, new GifOptions());

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
 * 1. When a developer needs to convert multi‑page DjVu documents into GIF images while preserving visual quality by applying Floyd‑Steinberg dithering to each page.
 * 2. When a document‑management system must generate low‑size preview GIFs from scanned DjVu files for web thumbnails, using Aspose.Imaging’s DitheringMethod to maintain contrast.
 * 3. When an e‑learning platform wants to transform DjVu lecture notes into page‑by‑page GIF slides with consistent dithering to ensure readability on devices that only support GIF.
 * 4. When a batch‑processing tool has to automate the extraction of each DjVu page, apply dithering, and save them as separate GIF files for archival or distribution.
 * 5. When a legacy application requires converting DjVu archives to GIF format for compatibility with older browsers, and needs to improve the monochrome rendering by using Floyd‑Steinberg dithering on every page.
 */