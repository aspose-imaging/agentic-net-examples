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
        // Hardcoded input and output paths
        string[] inputPaths = {
            @"C:\Images\source1.tif",
            @"C:\Images\source2.tif",
            @"C:\Images\source3.tif"
        };
        string outputPath = @"C:\Images\combined.tif";

        try
        {
            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare an array to hold the frames that will be added to the final TIFF
            TiffFrame[] frames = new TiffFrame[inputPaths.Length];

            // Define distinct compression types for each frame
            TiffCompressions[] compressions = new TiffCompressions[]
            {
                TiffCompressions.Lzw,          // First frame uses LZW compression
                TiffCompressions.CcittFax3,    // Second frame uses CCITT Group 3 Fax compression
                TiffCompressions.Deflate       // Third frame uses Deflate compression
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                // Load the source image (could be any raster format supported by Aspose.Imaging)
                using (RasterImage srcImage = (RasterImage)Image.Load(inputPaths[i]))
                {
                    // Configure TiffOptions for this specific frame
                    TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        BitsPerSample = new ushort[] { 8, 8, 8 }, // 8 bits per channel
                        ByteOrder = TiffByteOrder.LittleEndian,
                        Compression = compressions[i],
                        Photometric = TiffPhotometrics.Rgb,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Create a TiffFrame from the loaded image using the above options
                    TiffFrame frame = new TiffFrame(srcImage, frameOptions);

                    // Store the frame for later assembly
                    frames[i] = frame;
                }
                // Note: individual frames are disposed automatically when the TiffImage is disposed
            }

            // Assemble the frames into a multi‑page TIFF image
            using (TiffImage tiffImage = new TiffImage(frames))
            {
                // Save the combined TIFF to the output path
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
 * 1. When a developer needs to merge scanned documents from different sources into a single multi‑page TIFF while applying LZW, CCITT Group 3, and Deflate compression to reduce file size and preserve appropriate quality.
 * 2. When an application must create a combined TIFF for archival purposes, pulling pages from separate TIFF or JPEG files and assigning a specific compression algorithm to each frame to meet storage policy requirements.
 * 3. When a medical imaging system has to concatenate DICOM‑derived TIFF slices from various modalities into one file, using different compressions per slice to balance readability on legacy viewers and network bandwidth.
 * 4. When a publishing workflow requires assembling high‑resolution artwork pages into a single TIFF portfolio, applying lossless LZW to the first page and faster fax or deflate compression to subsequent pages for faster preview generation.
 * 5. When a cloud‑based service processes user‑uploaded images of different formats and needs to output a single multi‑frame TIFF with per‑frame compression settings to comply with client‑specified file‑size limits.
 */