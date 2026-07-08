using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = @"input\sample.png";
        string resizedPngPath = @"output\resized.png";
        string outputPdfPath = @"output\result.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the original PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Desired dimensions (example: double the size)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using bicubic interpolation (CubicConvolution)
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Save the high‑quality resized image as PNG (optional, can be omitted)
                image.Save(resizedPngPath, new PngOptions());

                // Convert the resized image to PDF
                image.Save(outputPdfPath, new PdfOptions());
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
 * 1. When a developer needs to double the resolution of a PNG logo for high‑resolution printing while preserving quality with bicubic interpolation before embedding it in a PDF catalog.
 * 2. When an e‑commerce platform must generate larger product thumbnails from original PNG assets and deliver them as PDF brochures for offline viewing.
 * 3. When a medical imaging application requires up‑scaling PNG scans using cubic convolution to meet regulatory size standards and then archive the results as PDF reports.
 * 4. When a content management system automates the conversion of user‑uploaded PNG graphics into PDF flyers, ensuring the resized images retain sharpness through bicubic scaling.
 * 5. When a desktop utility needs to batch‑process PNG screenshots, enlarge them for presentation slides, and save the final high‑quality output directly to PDF format.
 */