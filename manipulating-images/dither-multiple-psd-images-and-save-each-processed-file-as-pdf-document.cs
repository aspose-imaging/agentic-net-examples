using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.psd",
                @"C:\Images\input2.psd"
            };

            // Corresponding output PDF files
            string[] outputPaths = new string[]
            {
                @"C:\Images\output1.pdf",
                @"C:\Images\output2.pdf"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Apply dithering to the raster image (if applicable)
                    RasterImage raster = image as RasterImage;
                    if (raster != null)
                    {
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                    }

                    // Save the processed image as PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to batch‑convert Photoshop PSD files to PDF documents while applying Floyd‑Steinberg dithering to preserve visual quality for print‑ready output.
 * 2. When an automated workflow must generate PDF portfolios from multiple PSD artworks, using C# image loading and PdfOptions to ensure consistent dithering across all files.
 * 3. When a web service processes user‑uploaded PSD designs and returns PDF previews, applying raster dithering to improve gradient smoothness on screen.
 * 4. When a desktop application prepares marketing assets by converting several PSD files to PDFs with uniform dithering, guaranteeing that color transitions appear smooth on different devices.
 * 5. When a CI/CD pipeline validates graphic assets by converting source PSD files to PDF and applying Floyd‑Steinberg dithering to detect rendering issues before release.
 */