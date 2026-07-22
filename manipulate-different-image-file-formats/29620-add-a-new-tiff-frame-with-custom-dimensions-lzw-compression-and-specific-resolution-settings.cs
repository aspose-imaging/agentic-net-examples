using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.tif";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                int frameWidth = 200;
                int frameHeight = 150;

                TiffFrame newFrame = new TiffFrame(frameOptions, frameWidth, frameHeight);

                tiffImage.AddFrame(newFrame);

                tiffImage.HorizontalResolution = 300;
                tiffImage.VerticalResolution = 300;

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
 * 1. When a developer needs to create a multi‑page TIFF document for printing high‑resolution invoices, adding a new frame with custom width, height, LZW compression and 300 dpi resolution.
 * 2. When a medical imaging application must embed an additional scan slice into an existing DICOM‑converted TIFF file while preserving RGB color and using lossless LZW compression.
 * 3. When a GIS system wants to append a raster overlay of a specific area to a base map TIFF, setting the frame dimensions and resolution to match cartographic standards.
 * 4. When a digital archiving tool has to insert a thumbnail image into a multi‑page TIFF archive, ensuring the thumbnail uses 200 × 150 pixels, LZW compression and consistent resolution.
 * 5. When a publishing workflow requires adding a color‑corrected page to a multi‑page TIFF magazine file, with custom dimensions and 300 dpi resolution for accurate print output.
 */