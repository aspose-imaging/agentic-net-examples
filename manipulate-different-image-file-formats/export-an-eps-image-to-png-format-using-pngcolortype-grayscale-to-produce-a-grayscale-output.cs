using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/sample.eps";
        string outputPath = "output/sample_grayscale.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image epsImage = Image.Load(inputPath))
            {
                // Configure PNG options for grayscale output
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
                };

                // Save as PNG with the specified options
                epsImage.Save(outputPath, pngOptions);
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
 * 1. When a publishing system needs to generate low‑size, print‑ready grayscale previews of vector EPS logos for web catalogs.
 * 2. When an e‑learning platform converts teacher‑created EPS diagrams into PNG grayscale images to ensure consistent display on monochrome e‑readers.
 * 3. When a document management workflow extracts EPS artwork and stores it as grayscale PNG thumbnails for faster indexing and search.
 * 4. When a scientific reporting tool transforms EPS plots into grayscale PNGs to embed in black‑and‑white journal PDFs.
 * 5. When a legacy archival process requires converting EPS files to grayscale PNG format to comply with storage policies that prohibit color images.
 */