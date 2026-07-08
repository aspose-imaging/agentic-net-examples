using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "output.png";

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

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Get the first page (index 0)
                var djvuPage = djvuImage.Pages[0];

                // Save the page to a memory stream as PNG
                using (MemoryStream pngStream = new MemoryStream())
                {
                    djvuPage.Save(pngStream, new PngOptions());
                    pngStream.Position = 0;

                    // Load the PNG image from the memory stream
                    using (Image pngImage = Image.Load(pngStream))
                    {
                        // Define the rectangle to extract (x, y, width, height)
                        var exportRect = new Rectangle(50, 50, 300, 300);

                        // Crop the image to the specified rectangle
                        pngImage.Crop(exportRect);

                        // Save the cropped image to the output path
                        pngImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract a thumbnail of a specific region from a multi‑page DjVu document for display in a web gallery, they can load the DjVu page, crop a 300×300 rectangle at (50,50) and save it as a PNG.
 * 2. When building a document‑preview feature that shows only the relevant portion of a scanned blueprint stored as DjVu, the code can convert the selected rectangle to a high‑quality PNG for fast rendering in a C# application.
 * 3. When generating printable stickers from a large DjVu map, a developer can isolate the area of interest with a rectangle and export it as a PNG image to preserve transparency and resolution.
 * 4. When creating a machine‑learning dataset that requires small image patches from DjVu source files, this snippet loads the DjVu page, crops the defined region, and saves it as a PNG for model training.
 * 5. When developing a digital archiving tool that needs to preview a specific panel of a DjVu comic book page, the code extracts the panel using the rectangle coordinates and converts it to a PNG for UI display.
 */