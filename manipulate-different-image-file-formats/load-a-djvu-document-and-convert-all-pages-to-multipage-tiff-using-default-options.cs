using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options with default format
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Use default multi‑page options to include all pages
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages as a multipage TIFF file
                djvuImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to archive scanned DjVu documents into a single multipage TIFF for compatibility with legacy document management systems.
 * 2. When an application must batch‑convert a DjVu e‑book into a TIFF so each page can be displayed or printed using standard image viewers.
 * 3. When a workflow requires extracting all pages from a DjVu technical manual and saving them as a multipage TIFF to embed in a PDF generation pipeline.
 * 4. When a developer wants to provide a C# service that receives DjVu uploads and returns a consolidated TIFF file using Aspose.Imaging’s default conversion settings.
 * 5. When a Windows desktop tool must verify the existence of a DjVu file, create the output folder, and convert the entire document to a TIFF without manually handling each page.
 */