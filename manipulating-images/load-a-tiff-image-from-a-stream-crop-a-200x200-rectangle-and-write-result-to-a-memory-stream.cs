using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.tif";
            string outputPath = @"C:\Temp\output";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (required by the safety rules)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image from a file stream into a memory stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream inputMemory = new MemoryStream())
            {
                fileStream.CopyTo(inputMemory);
                inputMemory.Position = 0; // Reset stream position for reading

                // Load the image from the memory stream
                using (Image image = Image.Load(inputMemory))
                {
                    // Cast to TiffImage to access TIFF-specific methods
                    TiffImage tiffImage = (TiffImage)image;

                    // Define a 200x200 rectangle starting at the top‑left corner
                    var cropRect = new Rectangle(0, 0, 200, 200);
                    tiffImage.Crop(cropRect);

                    // Save the cropped image to a memory stream (PNG format)
                    using (MemoryStream outputMemory = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        tiffImage.Save(outputMemory, pngOptions);

                        // The memory stream now contains the cropped image data
                        Console.WriteLine($"Cropped image size (bytes): {outputMemory.Length}");
                    }
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
 * 1. When a developer needs to extract a 200 × 200 pixel region from a multi‑page TIFF stored in a database and return it as a PNG via a web API, they can load the TIFF from a stream, crop it, and write the result to a memory stream.
 * 2. When an image‑processing service must generate thumbnail previews of high‑resolution TIFF scans without creating temporary files on disk, this code loads the TIFF into memory, crops a square area, and returns the PNG bytes directly from a MemoryStream.
 * 3. When a desktop application has to display a specific portion of a large TIFF document in a UI control while preserving the original file, the developer can use the stream‑based load, crop, and in‑memory save pattern shown here.
 * 4. When an automated workflow needs to convert a selected area of a TIFF satellite image to PNG for downstream GIS analysis, the code demonstrates how to read the TIFF from a stream, perform a rectangular crop, and keep the result in memory.
 * 5. When a cloud function processes uploaded TIFF files and must quickly isolate a 200 × 200 pixel segment for validation or watermarking, this approach of streaming the input, cropping, and streaming the PNG output avoids disk I/O and improves performance.
 */