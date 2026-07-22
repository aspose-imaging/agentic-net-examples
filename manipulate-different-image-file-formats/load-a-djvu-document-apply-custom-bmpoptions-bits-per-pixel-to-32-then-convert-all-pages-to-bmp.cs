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
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputFolder = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Configure BMP options with 32 bits per pixel
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 32;

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page and save as BMP
                foreach (var pageObj in djvuImage.Pages)
                {
                    DjvuPage page = (DjvuPage)pageObj;
                    string outputPath = Path.Combine(outputFolder, $"page_{page.PageNumber}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page using the specified BMP options
                    page.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as high‑color‑depth BMP files for archival or printing purposes.
 * 2. When an application must batch‑convert scanned DjVu files into 32‑bit BMP images to preserve transparency and color fidelity before further image analysis.
 * 3. When a .NET service processes user‑uploaded DjVu files and generates separate BMP thumbnails with 32 bits per pixel for display in a web gallery.
 * 4. When a legacy system only accepts BMP images, requiring a C# routine that reads DjVu pages and outputs them using Aspose.Imaging’s BmpOptions with a 32‑bpp setting.
 * 5. When a developer wants to automate the migration of DjVu‑based documentation into BMP format while ensuring each page is saved in a dedicated output folder for downstream processing.
 */