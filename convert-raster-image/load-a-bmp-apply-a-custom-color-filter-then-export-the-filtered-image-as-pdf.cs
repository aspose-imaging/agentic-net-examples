using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Apply a simple custom color filter (increase red channel)
                if (image is RasterImage raster)
                {
                    for (int y = 0; y < raster.Height; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            Aspose.Imaging.Color original = raster.GetPixel(x, y);
                            int newRed = Math.Min(255, original.R + 50); // increase red by 50, clamp to 255
                            Aspose.Imaging.Color filtered = Aspose.Imaging.Color.FromArgb(original.A, newRed, original.G, original.B);
                            raster.SetPixel(x, y, filtered);
                        }
                    }
                }

                // Export the filtered image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert legacy BMP graphics to PDF while enhancing the red channel for branding or visual emphasis.
 * 2. When an application must generate printable PDF reports from BMP scans and apply a custom color filter to highlight specific details.
 * 3. When a batch‑processing tool has to read BMP files, increase their red intensity for better contrast, and save the results as PDF documents for archiving.
 * 4. When a C# service integrates Aspose.Imaging to transform user‑uploaded BMP images, apply a simple color correction, and deliver the output as a PDF for cross‑platform viewing.
 * 5. When a desktop utility must ensure the output folder exists, load a BMP, programmatically adjust pixel colors, and export the edited image to PDF for sharing with non‑technical stakeholders.
 */