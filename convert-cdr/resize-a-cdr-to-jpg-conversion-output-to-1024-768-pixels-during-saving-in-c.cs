using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try‑catch to report any unexpected errors.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file.
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Resize the image to the required dimensions (1024×768).
                cdrImage.Resize(1024, 768);

                // Save the rasterized image as JPEG.
                JpegOptions jpegOptions = new JpegOptions(); // default options
                cdrImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime exception without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate thumbnail previews of CorelDRAW (CDR) files for a product catalog, a developer can use this code to resize the rasterized image to 1024×768 pixels and save it as a JPEG.
 * 2. When an automated batch‑conversion service must convert legacy CDR artwork to web‑friendly JPGs with a fixed resolution for faster page loads, this snippet provides the C# logic to resize and save each file.
 * 3. When a desktop publishing workflow requires exporting CDR designs to a standard image format for printing proofs at a specific size, the code demonstrates how to load, resize, and save the image using Aspose.Imaging.
 * 4. When a content management system needs to store user‑uploaded CorelDRAW files as compressed JPEG previews of 1024×768 for preview panes, developers can apply this approach to ensure consistent dimensions.
 * 5. When a migration script moves graphic assets from a design repository to a cloud storage bucket and must standardize all images to 1024×768 JPEGs, this example shows the C# steps to resize and save each CDR file.
 */