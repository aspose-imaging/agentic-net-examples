using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputTiffPath = "input.tif";
            string inputPngPath = "frame.png";
            string outputPath = "output.tif";

            // Validate input TIFF file existence
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Validate input PNG file existence
            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the existing TIFF image from a stream
            using (FileStream tiffFileStream = new FileStream(inputTiffPath, FileMode.Open, FileAccess.Read))
            using (MemoryStream tiffMemoryStream = new MemoryStream())
            {
                tiffFileStream.CopyTo(tiffMemoryStream);
                tiffMemoryStream.Position = 0;

                using (TiffImage tiffImage = (TiffImage)Image.Load(tiffMemoryStream))
                {
                    // Load the additional PNG image from a stream
                    using (FileStream pngFileStream = new FileStream(inputPngPath, FileMode.Open, FileAccess.Read))
                    using (MemoryStream pngMemoryStream = new MemoryStream())
                    {
                        pngFileStream.CopyTo(pngMemoryStream);
                        pngMemoryStream.Position = 0;

                        using (RasterImage pngImage = (RasterImage)Image.Load(pngMemoryStream))
                        {
                            // Create a new TIFF frame from the PNG raster image
                            TiffFrame newFrame = new TiffFrame(pngImage);

                            // Add the new frame to the TIFF image
                            tiffImage.AddFrame(newFrame);
                        }
                    }

                    // Save the updated TIFF image to the output path
                    tiffImage.Save(outputPath);
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
 * 1. When a medical imaging system needs to append a diagnostic PNG overlay as a new page to an existing multi‑page TIFF scan stored in a database stream.
 * 2. When a document management workflow must merge a scanned PDF page saved as TIFF with a company logo PNG before archiving the combined multi‑frame TIFF.
 * 3. When a GIS application wants to add a satellite image PNG as an additional layer to a multi‑page TIFF map that is being processed from a network stream.
 * 4. When an e‑commerce platform generates a product catalog TIFF and needs to insert a promotional banner PNG as an extra frame without writing intermediate files to disk.
 * 5. When a digital archiving tool reads a TIFF file from a memory stream and programmatically appends a thumbnail PNG to create a searchable multi‑frame TIFF for long‑term storage.
 */