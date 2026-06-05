using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Options for the new frame with custom photometric interpretation
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8 };
                frameOptions.Photometric = TiffPhotometrics.MinIsBlack;
                frameOptions.Compression = TiffCompressions.Jpeg;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a new 100x100 frame
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the frame with a solid gray color
                Graphics graphics = new Graphics(newFrame);
                using (SolidBrush brush = new SolidBrush(Color.Gray))
                {
                    graphics.FillRectangle(brush, newFrame.Bounds);
                }

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF using JPEG compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.Photometric = TiffPhotometrics.Rgb;
                saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                saveOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to embed a grayscale thumbnail into a multi‑page TIFF archive for medical imaging, using a custom MinIsBlack photometric interpretation and JPEG compression to keep the file size small.
 * 2. When a GIS application must add a small raster overlay with specific BitsPerSample and planar configuration to an existing satellite‑image TIFF stack, preserving JPEG compression for efficient storage.
 * 3. When an e‑commerce platform wants to generate a low‑resolution preview frame inside a product catalog TIFF file, filling it with a solid gray color and saving the result with JPEG compression to speed up page loads.
 * 4. When a document management system requires inserting a placeholder page with custom photometric settings into a scanned multi‑page TIFF and ensure the final document remains compatible with JPEG‑compressed TIFF viewers.
 * 5. When a digital archiving workflow programmatically adds a new 100×100 frame with custom photometric interpretation to a TIFF file and saves it using JPEG compression to optimize storage space.
 */