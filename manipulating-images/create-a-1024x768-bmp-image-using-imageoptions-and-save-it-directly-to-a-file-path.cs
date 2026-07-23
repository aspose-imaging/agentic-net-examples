using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false),
                ResolutionSettings = new ResolutionSetting(96.0, 96.0)
            };

            // Create a 1024x768 image using the options
            using (Image image = Image.Create(bmpOptions, 1024, 768))
            {
                // Fill the image with white background
                Graphics graphics = new Graphics(image);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, image.Bounds);

                // Save the image (writes to the file specified in Source)
                image.Save();
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
 * 1. When a legacy printing workflow requires a 24‑bit 1024×768 BMP file with 96 DPI, a developer can use Aspose.Imaging for .NET to create the blank canvas and save it directly to a file path.
 * 2. When a game level editor expects a white BMP background of exact dimensions, a C# program can generate the 1024×768 BMP using ImageOptions and store it on disk for the editor to load.
 * 3. When exporting a data‑visualization chart to a raster image for a Word document, a developer can create a 1024×768 BMP with Aspose.Imaging, fill it with a background, and save it to a specified folder.
 * 4. When building a batch image‑processing pipeline that adds watermarks to a template, a developer can first generate a 1024×768 BMP file with the required resolution using Image.Create and then reuse it for each watermark operation.
 * 5. When implementing a document conversion service that converts PDFs to BMP, the service can start by creating an empty 1024×768 BMP file with Aspose.Imaging for .NET and then render each PDF page onto this canvas before saving.
 */