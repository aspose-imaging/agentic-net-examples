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
            // Hardcoded input DjVu file path
            string inputPath = "input.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory
            string outputDir = "output";

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Define cropping rectangle (example values)
                    Rectangle cropRect = new Rectangle(50, 50, 400, 300);

                    // Process each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Apply cropping
                        page.Crop(cropRect);

                        // Prepare output file path for this page
                        string outputPath = Path.Combine(outputDir, $"page{page.PageNumber}.bmp");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as BMP
                        page.Save(outputPath, new BmpOptions());
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract specific regions from each page of a multi‑page DjVu document and save them as high‑resolution BMP files for archival or printing purposes.
 * 2. When an application must automatically generate thumbnail previews of scanned DjVu pages by cropping a central area and converting the result to BMP for compatibility with legacy Windows imaging components.
 * 3. When a document‑processing workflow requires batch conversion of DjVu pages to BMP while discarding margins or watermarks through a predefined cropping rectangle.
 * 4. When a digital forensics tool has to isolate and export the content of each DjVu page as BMP images after removing surrounding noise using Aspose.Imaging’s page‑level Crop method.
 * 5. When a content‑management system needs to programmatically render selected portions of DjVu files as BMP assets for use in web galleries or e‑learning modules.
 */