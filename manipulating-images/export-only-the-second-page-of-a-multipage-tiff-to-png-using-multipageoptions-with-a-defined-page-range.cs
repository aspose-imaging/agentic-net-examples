// HOW-TO: Export Second Page of Multipage TIFF to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\multipage.tif";
            string outputPath = @"C:\Images\page2.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // If the image supports multiple pages and has at least two pages,
                // configure MultiPageOptions to export only the second page (index 1)
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage != null && multipage.PageCount > 1)
                {
                    pngOptions.MultiPageOptions = new MultiPageOptions(new int[] { 1 });
                }

                // Save the selected page as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to extract a single page from a multi‑page scanned TIFF document and save it as a PNG for web preview.
 * 2. When generating a thumbnail of a specific page in a multi‑page fax TIFF to embed in an email attachment.
 * 3. When converting a particular frame of a multi‑page medical image stored as TIFF to PNG for analysis in a .NET application.
 * 4. When isolating a page from a multi‑page invoice TIFF to feed into an OCR engine that only accepts PNG input.
 * 5. When creating a printable PNG of a selected page from a multi‑page blueprint TIFF for inclusion in a CAD report.
 */
