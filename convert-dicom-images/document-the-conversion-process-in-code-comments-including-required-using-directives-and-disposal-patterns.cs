using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Wrap the entire processing logic in a try-catch block to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input and output file paths (relative to the application directory).
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/sample.tif";

            // Verify that the input file exists; if not, report and exit.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists before attempting to save the file.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image. The using statement ensures the image is disposed properly.
            using (Image image = Image.Load(inputPath))
            {
                // Create TIFF export options. Here we use the default TIFF format.
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image in TIFF format using the specified options.
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime exception message without crashing the application.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive photographic assets in a lossless, industry‑standard format, they can convert JPEG files to TIFF using Aspose.Imaging for .NET.
 * 2. When a medical imaging application requires images to be stored as multi‑page TIFFs for compatibility with DICOM workflows, this code can be adapted to batch‑convert source JPEG scans.
 * 3. When a printing service must supply high‑resolution TIFF files to printers that do not accept JPEG, the conversion routine ensures the correct file format and color fidelity.
 * 4. When a document management system ingests user‑uploaded JPEG pictures but stores all documents as TIFF for long‑term preservation, developers can use this snippet to perform the format change on upload.
 * 5. When an e‑commerce platform generates product catalogs that need TIFF images for offline publishing or archival, the code provides a simple way to transform web‑optimized JPEGs into print‑ready TIFFs.
 */