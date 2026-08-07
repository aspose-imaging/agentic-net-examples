using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input GIF files and output TIFF file
            string[] inputPaths = new string[]
            {
                "input1.gif",
                "input2.gif",
                "input3.gif"
            };
            string outputPath = "output.tif";

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

            // Prepare TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Create an empty TIFF image (size will be adjusted by added frames)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 1, 1))
            {
                // Add each GIF image as a separate TIFF frame
                foreach (var inputPath in inputPaths)
                {
                    // Load GIF (or any raster image) from file
                    RasterImage raster = (RasterImage)Image.Load(inputPath);

                    // Create a TIFF frame from the loaded raster image
                    TiffFrame frame = new TiffFrame(raster);

                    // Add the frame to the TIFF image
                    tiffImage.AddFrame(frame);
                }

                // Remove the initial default frame created by Image.Create
                TiffFrame activeFrame = tiffImage.ActiveFrame;
                if (tiffImage.Frames.Length > 1)
                {
                    tiffImage.ActiveFrame = tiffImage.Frames[1];
                    tiffImage.RemoveFrame(0);
                }
                activeFrame.Dispose();

                // Save the multipage TIFF
                tiffImage.Save();
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
 * 1. When a developer needs to combine several animated GIF screenshots into a single multipage TIFF for archival or printing purposes.
 * 2. When an application must generate a multi‑page document from individual GIF icons to embed in a PDF or Word report.
 * 3. When a medical imaging system converts a series of GIF‑based scan slices into a single TIFF stack for compatibility with DICOM viewers.
 * 4. When a web service creates a downloadable TIFF portfolio from user‑uploaded GIF artwork for high‑resolution printing.
 * 5. When a batch processing tool consolidates daily GIF charts into one multipage TIFF for automated email distribution.
 */