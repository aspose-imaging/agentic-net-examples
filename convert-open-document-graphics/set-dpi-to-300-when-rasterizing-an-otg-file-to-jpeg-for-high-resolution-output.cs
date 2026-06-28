using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_300dpi.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with 300 dpi resolution
                JpegOptions jpegOptions = new JpegOptions
                {
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    Quality = 100 // optional: maximum quality
                };

                // Set vector rasterization options for OTG conversion
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original page size
                };
                jpegOptions.VectorRasterizationOptions = otgOptions;

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When generating print‑ready marketing brochures from vector OTG artwork, a developer can rasterize the file to a 300 dpi JPEG to meet printer resolution requirements.
 * 2. When converting architectural floor‑plan OTG files to high‑resolution JPEGs for inclusion in PDF construction documents, the code ensures the output meets the 300 dpi standard for clear detail.
 * 3. When creating product catalog images from OTG vector graphics, a developer uses this code to produce 300 dpi JPEGs that retain sharpness when printed on glossy paper.
 * 4. When exporting OTG diagrams to JPEG for archival in a digital asset management system that expects 300 dpi images for consistent metadata handling, the code provides the required resolution.
 * 5. When a web‑based reporting tool needs to embed OTG charts as high‑resolution JPEGs for downloadable PDF reports, the developer sets the DPI to 300 to guarantee legible print output.
 */