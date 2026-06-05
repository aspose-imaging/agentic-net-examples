using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_output.tif";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF export options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Configure vector rasterization options for CDR
                var rasterOptions = new CdrRasterizationOptions
                {
                    // Apply anti‑alias smoothing to reduce jagged lines
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Optional: preserve original size
                    PageSize = image.Size,
                    // Optional: set background to white
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                tiffOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as TIFF using the configured options
                image.Save(outputPath, tiffOptions);
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
 * 1. When converting CorelDRAW (.cdr) artwork to high‑resolution TIFF for printing, a developer can use this code to apply anti‑alias smoothing and avoid jagged edges.
 * 2. When generating archival TIFF files from vector CDR designs for a document management system, the smoothing mode ensures clean line rendering.
 * 3. When preparing CDR graphics for inclusion in a PDF or Word report that requires TIFF images, the code smooths the rasterized output to improve visual quality.
 * 4. When automating batch conversion of CDR logos to TIFF for a web‑based asset pipeline, applying SmoothingMode.AntiAlias prevents pixelated edges on different screen sizes.
 * 5. When creating TIFF previews of CDR files for a digital asset catalog, the anti‑alias smoothing produces professional‑grade thumbnails without manual editing.
 */