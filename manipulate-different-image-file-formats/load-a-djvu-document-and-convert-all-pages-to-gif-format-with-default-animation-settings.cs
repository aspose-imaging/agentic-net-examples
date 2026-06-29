using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

namespace DjvuToGifConverter
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "output";

            try
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists (creates if missing)
                Directory.CreateDirectory(outputDirectory);

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu document
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // Iterate through each page
                        foreach (Image page in djvuImage.Pages)
                        {
                            // Cast to DjvuPage to access PageNumber
                            DjvuPage djvuPage = (DjvuPage)page;

                            // Build output file path for this page
                            string outputPath = Path.Combine(outputDirectory,
                                $"page_{djvuPage.PageNumber}.gif");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as GIF with default options
                            djvuPage.Save(outputPath, new GifOptions());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and provide them as animated GIF files for web preview.
 * 2. When an archival system must convert scanned DjVu books into GIF sequences to support legacy browsers that only display GIF images.
 * 3. When a digital publishing workflow requires batch conversion of DjVu pages to GIF format with default animation settings for inclusion in e‑learning modules.
 * 4. When a document management application needs to generate thumbnail‑style GIF previews of every page in a DjVu file for quick visual indexing.
 * 5. When a C# service automates the transformation of DjVu slide decks into GIF animations to embed in PowerPoint presentations or online slideshows.
 */