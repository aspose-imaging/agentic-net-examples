using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/processed.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Dither the raster image
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette
                    raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                }

                // Prepare PDF export options with smoothing mode set
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Save the processed image as PDF
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
 * 1. When a developer needs to convert a high‑resolution Photoshop PSD file into a compact 1‑bit PDF for printing on low‑cost monochrome printers, applying Floyd‑Steinberg dithering to preserve detail while disabling smoothing.
 * 2. When an application must generate archival PDF documents from layered PSD assets, ensuring the rasterized output uses a white background, exact page dimensions, and no anti‑aliasing to meet compliance standards.
 * 3. When a web service processes user‑uploaded PSD designs and returns a PDF preview that mimics the original appearance by dithering the image to a limited palette and preserving sharp edges with SmoothingMode.None.
 * 4. When a batch‑processing tool automates the conversion of multiple PSD files into PDF portfolios, using Aspose.Imaging to cache raster data, apply 1‑bit dithering, and export each file with consistent page size and background color.
 * 5. When a digital publishing workflow requires converting color‑rich PSD artwork into a PDF suitable for e‑ink devices, leveraging Floyd‑Steinberg dithering and disabling smoothing to optimize readability on grayscale screens.
 */