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
            string inputPath = "sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Cropping rectangle parameters (example values)
            int cropX = 10;
            int cropY = 10;
            int cropWidth = 200;
            int cropHeight = 200;

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    // Access page as DjvuPage
                    using (DjvuPage page = (DjvuPage)djvuImage.Pages[i])
                    {
                        // Apply cropping
                        page.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

                        // Prepare output BMP file path
                        string outputPath = Path.Combine("output", $"page_{i + 1}.bmp");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save cropped page as BMP
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
 * 1. When a developer needs to extract specific regions from each page of a multi‑page DjVu file and save them as BMP images for further analysis or printing.
 * 2. When an application must generate thumbnail previews of scanned documents stored in DjVu format by cropping a central area and converting each page to BMP.
 * 3. When a workflow requires batch processing of DjVu archives to isolate a logo or watermark area on every page before archiving the cropped pages as BMP files.
 * 4. When a document‑management system needs to convert selected portions of DjVu pages into BMP for compatibility with legacy Windows imaging tools.
 * 5. When a developer wants to automate the preparation of image assets from DjVu e‑books by cropping each page to a fixed rectangle and exporting them as BMP for use in a game engine.
 */