using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"c:\temp\source.png";
            string outputPath = @"c:\temp\multiframe.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Options for the first frame (standard RGB photometric)
            TiffOptions rgbOptions = new TiffOptions(TiffExpectedFormat.Default);
            rgbOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            rgbOptions.Compression = TiffCompressions.Lzw;
            rgbOptions.Photometric = TiffPhotometrics.Rgb;
            rgbOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create first frame from the source image
            TiffFrame frame1 = new TiffFrame(inputPath, rgbOptions);

            // Options for the second frame (custom photometric: MinIsBlack)
            TiffOptions customOptions = new TiffOptions(TiffExpectedFormat.Default);
            customOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            customOptions.Compression = TiffCompressions.Lzw;
            customOptions.Photometric = TiffPhotometrics.MinIsBlack; // custom interpretation
            customOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create second frame from the same source image but with custom photometric
            TiffFrame frame2 = new TiffFrame(inputPath, customOptions);

            // Assemble a multi‑frame TIFF image
            using (TiffImage tiffImage = new TiffImage(new TiffFrame[] { frame1, frame2 }))
            {
                // Save the multi‑frame image using LZW compression (already set in options)
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
 * 1. When a developer needs to generate a multi‑frame TIFF file that combines a standard RGB image with a version using a custom photometric interpretation (e.g., MinIsBlack) for compatibility with legacy imaging software, they can use this C# Aspose.Imaging code with LZW compression.
 * 2. When building a document scanning solution that stores each scanned page as a separate TIFF frame while applying different photometric settings for color and black‑and‑white pages, this code lets the developer create the multi‑frame TIFF and reduce file size with LZW.
 * 3. When creating satellite or aerial imagery archives where one frame preserves the original RGB data and another frame provides a grayscale representation using a custom photometric interpretation, the code enables the developer to package both frames into a single compressed TIFF.
 * 4. When developing a medical imaging application that must embed both a full‑color diagnostic image and a contrast‑enhanced version with a MinIsBlack photometric tag for older DICOM viewers, the developer can use this example to assemble the frames and apply lossless LZW compression.
 * 5. When exporting CAD or engineering drawings to a multi‑page TIFF where the first page uses standard RGB and subsequent pages use a custom photometric interpretation for line art, this C# snippet shows how to create the frames and save the file efficiently with LZW compression.
 */