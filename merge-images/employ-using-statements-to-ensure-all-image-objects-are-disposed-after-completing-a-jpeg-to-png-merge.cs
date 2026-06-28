using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string jpegPath = "input.jpg";
            string pngPath = "input.png";
            string outputPath = "output.png";

            // Validate input files
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }
            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load source images
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegPath))
            using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
            {
                // Calculate canvas size for horizontal merge
                int canvasWidth = jpegImage.Width + pngImage.Width;
                int canvasHeight = Math.Max(jpegImage.Height, pngImage.Height);

                // Prepare PNG options with bound source
                Source fileSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions { Source = fileSource };

                // Create canvas bound to the output file
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Copy JPEG image at (0,0)
                    Rectangle jpegBounds = new Rectangle(0, 0, jpegImage.Width, jpegImage.Height);
                    canvas.SaveArgb32Pixels(jpegBounds, jpegImage.LoadArgb32Pixels(jpegImage.Bounds));

                    // Copy PNG image next to JPEG
                    Rectangle pngBounds = new Rectangle(jpegImage.Width, 0, pngImage.Width, pngImage.Height);
                    canvas.SaveArgb32Pixels(pngBounds, pngImage.LoadArgb32Pixels(pngImage.Bounds));

                    // Save the merged image (canvas is already bound to outputPath)
                    canvas.Save();
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
 * 1. When a developer needs to generate a side‑by‑side preview of a high‑resolution JPEG photo and a transparent PNG overlay for an e‑commerce product page, they can use this code to merge the two images into a single PNG file while automatically disposing the Image objects.
 * 2. When an application must combine a scanned JPEG receipt with a PNG company logo into one printable PNG receipt, this snippet provides a straightforward way to concatenate the images horizontally and ensure proper resource cleanup with using statements.
 * 3. When a reporting tool has to create a composite chart by appending a JPEG chart image to a PNG legend image before exporting to PNG, the code demonstrates how to calculate the canvas size, merge the images, and release memory safely.
 * 4. When a mobile backend service needs to bundle a user‑uploaded JPEG avatar with a PNG frame overlay into a single PNG asset for storage, the example shows how to load, merge, and save the result while handling file I/O and disposal correctly.
 * 5. When a batch‑processing script must convert pairs of JPEG and PNG files into merged PNG composites for archival purposes, this example illustrates the use of Aspose.Imaging’s Image.Load, Image.Create, and using blocks to avoid memory leaks.
 */