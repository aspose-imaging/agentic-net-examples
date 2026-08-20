// HOW-TO: Apply Emboss 5x5 Filter to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\highres.tif";
            string outputPath = @"C:\Images\highres_emboss.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Create convolution filter options using the built‑in Emboss5x5 kernel
                var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);

                // Apply the emboss filter to the whole image
                tiffImage.Filter(tiffImage.Bounds, embossOptions);

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to add a 3‑D embossed effect to a high‑resolution scanned document before publishing it as a PNG.
 * 2. When converting archival TIFF images to web‑friendly PNG format while applying a convolution filter for visual enhancement.
 * 3. When processing satellite or medical TIFF imagery to highlight edges with an emboss filter and output a lossless PNG for analysis.
 * 4. When automating batch image preparation for a digital catalog, applying emboss to each TIFF and saving the results as PNG files.
 * 5. When creating stylized thumbnails from large TIFF files, using the built‑in Emboss5x5 kernel to give depth before converting to PNG.
 */
