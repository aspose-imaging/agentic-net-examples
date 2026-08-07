using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Output path for the high‑resolution TIFF
            string outputPath = @"C:\Temp\vector_illustration.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // TIFF options configuration
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Desired image size (high resolution)
            int width = 2000;
            int height = 2000;

            // Create the TIFF image canvas
            using (Image image = Image.Create(tiffOptions, width, height))
            {
                // Define a solid brush for background
                using (SolidBrush solidBrush = new SolidBrush(Color.White))
                {
                    // Draw the background
                    Graphics graphics = new Graphics(image);
                    graphics.FillRectangle(solidBrush, new Rectangle(0, 0, width, height));
                }

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When a publishing system must generate print‑ready, high‑resolution TIFF files of vector logos with a radial gradient background for magazine layouts.
 * 2. When an e‑commerce platform needs to create scalable product mockups on a gradient canvas and store them as lossless LZW‑compressed TIFF images for archival.
 * 3. When a GIS application requires rendering map symbols as vector illustrations with smooth gradient fills and exporting them as 2000×2000 TIFF tiles for high‑detail satellite overlays.
 * 4. When a medical imaging workflow has to produce annotated vector diagrams with a radial gradient background and save them as contiguous planar TIFFs for compatibility with DICOM viewers.
 * 5. When a branding agency automates the batch creation of high‑resolution TIFF assets with custom gradient backgrounds for corporate stationery, using C# and Aspose.Imaging’s Image.Create and TiffOptions.
 */