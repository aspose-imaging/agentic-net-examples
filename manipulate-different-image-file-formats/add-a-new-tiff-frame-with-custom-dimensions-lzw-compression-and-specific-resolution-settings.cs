using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Configure options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                frameOptions.ResolutionUnit = TiffResolutionUnits.Inch;
                frameOptions.Xresolution = new TiffRational(300, 1); // 300 DPI
                frameOptions.Yresolution = new TiffRational(300, 1); // 300 DPI

                // Create a new frame with custom dimensions
                int frameWidth = 200;
                int frameHeight = 150;
                TiffFrame newFrame = new TiffFrame(frameOptions, frameWidth, frameHeight);

                // Optional: fill the frame with a simple gradient
                LinearGradientBrush gradient = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(newFrame.Width, newFrame.Height),
                    Color.LightBlue,
                    Color.LightGreen);
                Graphics graphics = new Graphics(newFrame);
                graphics.FillRectangle(gradient, newFrame.Bounds);

                // Add the new frame to the existing TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the modified TIFF image
                tiffImage.Save(outputPath);
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
 * 1. When a medical imaging application needs to append a high‑resolution, LZW‑compressed scan as a new page to an existing multi‑page TIFF file for efficient storage and quick retrieval.
 * 2. When a GIS system generates a raster map layer with custom dimensions and 300 DPI resolution, then adds it as an additional frame to a TIFF dataset for seamless overlay with other geospatial data.
 * 3. When a document management workflow creates a thumbnail preview of a scanned contract, using a 200 × 150 pixel frame with LZW compression to keep the TIFF file size low while preserving image quality.
 * 4. When a printing service prepares a multi‑page TIFF brochure, inserting a color gradient banner frame with specific inch‑based resolution settings to ensure accurate color reproduction on high‑end printers.
 * 5. When a scientific research tool records experimental results as separate image frames, adding each new measurement as a custom‑sized, LZW‑compressed TIFF frame with consistent DPI for standardized analysis across datasets.
 */