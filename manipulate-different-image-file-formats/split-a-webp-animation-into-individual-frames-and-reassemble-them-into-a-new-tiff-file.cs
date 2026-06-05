using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\animation.webp";
            string outputPath = "Output\\result.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (WebPImage webp = new WebPImage(inputPath))
            {
                // Determine the number of frames/pages
                int pageCount = 1;
                if (webp is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    pageCount = multipage.PageCount;
                }

                // Configure TIFF options for multi-page output
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, pageCount));

                // Save frames as a new multi-page TIFF file
                webp.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert an animated WebP advertisement into a multi‑page TIFF for archival in a digital asset management system.
 * 2. When a web application must extract each frame of a WebP animation to generate printable TIFF slides for a marketing presentation.
 * 3. When a mobile app backend processes user‑uploaded animated WebP stickers and stores them as TIFF files for compatibility with legacy image editors.
 * 4. When an e‑learning platform converts animated WebP tutorials into multi‑page TIFFs to embed them in PDF course materials.
 * 5. When a scientific imaging workflow requires turning a WebP time‑lapse sequence into a TIFF stack for analysis with image‑processing tools.
 */