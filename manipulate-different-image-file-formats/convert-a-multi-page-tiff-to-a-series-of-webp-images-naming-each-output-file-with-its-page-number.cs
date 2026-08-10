// HOW-TO: Convert Multi‑Page TIFF to Separate WebP Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/multipage.tif";
            string outputDir = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multipage = tiffImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input image is not a multipage image.");
                    return;
                }

                int pageIndex = 0;
                foreach (Image page in multipage.Pages)
                {
                    // Build output file path with page number
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.webp");

                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a WebP image
                    page.Save(outputPath, new WebPOptions());

                    // Dispose the page image
                    page.Dispose();

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
 * 1. When you need to extract each page of a scanned multipage TIFF document and serve them as lightweight WebP images on a website.
 * 2. When an application must generate thumbnails for every page of a multi‑page TIFF for a gallery view, using WebP to reduce bandwidth.
 * 3. When a document‑management system converts archival TIFF files into individual WebP files for easier indexing and retrieval.
 * 4. When a batch‑processing script has to split a multi‑page TIFF into separate images for further per‑page analysis or OCR, preferring WebP for its compression.
 * 5. When a mobile app requires each page of a TIFF to be delivered as a WebP asset to improve loading speed on low‑bandwidth connections.
 */
