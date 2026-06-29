using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths (relative)
            string inputPath = "Input/sample.png";
            string outputPath = "Output/inverted.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;

                // Ensure image data is cached
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Define the full image rectangle
                var rect = new Rectangle(0, 0, raster.Width, raster.Height);

                // Load ARGB pixels
                int[] pixels = raster.LoadArgb32Pixels(rect);

                // Invert colors (bitwise NOT)
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = ~pixels[i];
                }

                // Write the inverted pixels back
                raster.SaveArgb32Pixels(rect, pixels);

                // Save the result as PDF
                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a printable PDF version of a scanned document with a negative (color‑inverted) effect for archival or visual inspection, they can load the PNG, invert the ARGB pixels, and save as PDF using Aspose.Imaging for .NET.
 * 2. When an application must automatically create high‑contrast PDF previews of user‑uploaded images (e.g., for accessibility compliance), the code can load the raster image, perform bitwise NOT color inversion, and export the result as a PDF.
 * 3. When a batch‑processing tool has to convert a folder of PNG graphics into PDF files with inverted colors for a marketing campaign’s “night‑mode” assets, this snippet demonstrates the required C# image manipulation and PDF saving steps.
 * 4. When a developer is building a diagnostic utility that highlights image defects by inverting colors and then bundles the output into a PDF report, the example shows how to cache raster data, manipulate pixels, and generate the PDF with Aspose.Imaging.
 * 5. When integrating a document management system that stores images as PDFs with a visual “negative” effect for security watermarking, the code provides a straightforward way to load a raster image, invert its colors, and export the result as a PDF file.
 */