using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output_cropped.png";

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
            // Load the CDR vector image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Set up rasterization options (default constructor)
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    // Example: set background to white (optional)
                    BackgroundColor = Color.White
                };

                // Configure PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Temporary rasterized file path
                string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

                // Rasterize the vector image to a PNG file
                cdrImage.Save(tempRasterPath, pngOptions);

                // Load the rasterized PNG for cropping
                using (RasterImage rasterImage = (RasterImage)Image.Load(tempRasterPath))
                {
                    // Define the rectangular area to keep (x, y, width, height)
                    Rectangle cropArea = new Rectangle(100, 100, 300, 200);

                    // Crop the image to the defined area
                    rasterImage.Crop(cropArea);

                    // Save the cropped image to the final output path
                    rasterImage.Save(outputPath);
                }

                // Clean up temporary raster file
                if (File.Exists(tempRasterPath))
                {
                    File.Delete(tempRasterPath);
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
 * 1. When a developer needs to extract a logo or emblem from a CorelDRAW (CDR) vector file and save it as a PNG with a white background, this code rasterizes the vector and crops the defined rectangle to isolate the logo.
 * 2. When an e‑commerce platform wants to generate product thumbnails by removing the surrounding background from a CDR design and keeping only the product area, the code provides selective rasterization and cropping.
 * 3. When a marketing team requires a high‑resolution PNG of a specific diagram section from a multi‑page CDR file for a presentation, the code lets developers define the rectangle to capture that section after rasterization.
 * 4. When a content management system must convert a CDR illustration into a web‑ready PNG while discarding unwanted margins, the code uses CdrRasterizationOptions and a crop rectangle to achieve clean output.
 * 5. When an automated workflow needs to batch‑process CDR files to isolate and export only the central artwork for printing, this code demonstrates how to rasterize the vector, set a background color, and crop the area of interest.
 */