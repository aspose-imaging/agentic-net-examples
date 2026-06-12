using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Get the first (or only) page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                // Set PNG options (transparency is preserved by default)
                PngOptions pngOptions = new PngOptions();

                // Save the page as PNG
                page.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to embed a single‑page CorelDRAW (CDR) illustration into a web page that only supports PNG with alpha transparency, a developer can use this code to convert the CDR to a transparent PNG.
 * 2. When an automated build pipeline must generate preview thumbnails for CDR assets stored in a repository, the snippet can be called to produce PNG previews that retain the original transparency.
 * 3. When a content‑management system imports legacy CDR files and must display them on mobile devices, developers can run this conversion to create PNG images that preserve transparent backgrounds.
 * 4. When a batch‑processing tool extracts individual pages from multi‑page CDR documents and needs to save each page as a lossless PNG for further editing in Photoshop, this code provides the required conversion.
 * 5. When an e‑commerce platform receives product artwork in CDR format and requires a web‑ready PNG with transparent background for product listings, the developer can apply this snippet to perform the conversion.
 */