// HOW-TO: Convert EMF to JPEG with Camera EXIF Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Exif;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify that the source EMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for EMF → raster conversion
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = ((EmfImage)image).Size,   // Preserve original size
                    BackgroundColor = Color.White       // Optional background
                };

                // Create EXIF data to embed in the JPEG
                var exif = new JpegExifData
                {
                    Make = "MyCameraMaker",   // Camera manufacturer
                    Model = "MyCameraModel",  // Camera model
                    // Additional EXIF fields can be set here as needed
                };

                // Set up JPEG save options, including EXIF and rasterization
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ExifData = exif,
                    Quality = 90               // JPEG quality (0‑100)
                };

                // Save the image as JPEG with embedded EXIF metadata
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display vector EMF drawings on web pages that only support raster JPEG images while preserving the original dimensions.
 * 2. When a reporting system must generate JPEG thumbnails from EMF charts and include camera make and model information for downstream analytics.
 * 3. When migrating legacy EMF assets to a photo‑management database that requires EXIF fields for sorting and searching.
 * 4. When automating batch conversion of engineering diagrams to JPEG for inclusion in PDFs, and you want to tag them with consistent camera metadata.
 * 5. When creating a digital archive of scanned documents where the source is EMF and you need to embed EXIF data to satisfy metadata standards.
 */
