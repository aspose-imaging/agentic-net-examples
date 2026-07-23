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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\multipage.tif";
            string outputPath = @"C:\Images\page2.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multipage TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to IMultipageImage to access page information
                IMultipageImage multipage = image as IMultipageImage;

                // Check that the image has at least two pages
                if (multipage != null && multipage.PageCount > 1)
                {
                    // Prepare PNG save options
                    PngOptions pngOptions = new PngOptions();

                    // Export only the second page (index 1)
                    pngOptions.MultiPageOptions = new MultiPageOptions(new int[] { 1 });

                    // Save the selected page as PNG
                    image.Save(outputPath, pngOptions);
                }
                else
                {
                    Console.Error.WriteLine("The input image does not contain a second page.");
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
 * 1. When a developer needs to extract the second page of a multi‑page TIFF (such as a scanned invoice) and convert it to a PNG for web display.
 * 2. When an application must generate a lossless PNG thumbnail of a specific page in a multi‑page medical TIFF image.
 * 3. When a batch process has to isolate a particular frame from a multi‑page fax document and save it as a PNG for archival purposes.
 * 4. When a reporting tool requires converting only the second page of a multi‑page engineering drawing TIFF into a PNG to embed in a PDF report.
 * 5. When a migration script must programmatically convert a selected page of a multi‑page TIFF archive to PNG for compatibility with a mobile app.
 */