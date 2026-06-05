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
        string inputPath = "input.tif";
        string newFramePath = "newframe.jpg";
        string outputPath = "output/output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(newFramePath))
            {
                Console.Error.WriteLine($"File not found: {newFramePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)Image.Load(newFramePath))
                {
                    TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);
                    frameOptions.Compression = TiffCompressions.Jpeg;
                    frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                    frameOptions.Photometric = TiffPhotometrics.Rgb;
                    frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                    TiffFrame newFrame = new TiffFrame(raster, frameOptions);
                    tiffImage.AddFrame(newFrame);
                }

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
 * 1. When a healthcare application needs to append a new X‑ray scan as a JPEG‑compressed page to an existing multi‑page TIFF patient record while preserving DICOM metadata.
 * 2. When a GIS system must add a high‑resolution satellite photo as an additional frame to a TIFF catalog, using JPEG compression to keep file size low and embedding a custom comment tag that describes the acquisition date.
 * 3. When a legal document management platform wants to insert a scanned signature page into a multi‑page TIFF contract, compressing the page with JPEG to reduce storage and adding a comment tag indicating the signer’s name.
 * 4. When a digital publishing workflow needs to combine a newly created cover image with an existing TIFF manuscript, using Aspose.Imaging in C# to add the JPEG‑compressed cover as a new frame and store a comment tag with the ISBN.
 * 5. When an archival system for historical photographs adds a restored JPEG image as an extra frame to an original TIFF collection, applying JPEG compression for efficient archiving and attaching a comment tag that records the restoration technician’s notes.
 */