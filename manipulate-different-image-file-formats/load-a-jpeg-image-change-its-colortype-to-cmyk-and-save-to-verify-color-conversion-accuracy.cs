using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_cmyk.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with CMYK color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk,
                    // Optional: preserve quality
                    Quality = 100
                };

                // Save the image as CMYK JPEG
                image.Save(outputPath, saveOptions);
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
 * 1. When preparing print‑ready marketing materials, a developer can load a JPEG, convert it to CMYK, and save it to ensure colors match the printing press.
 * 2. When migrating a web‑based photo gallery to a workflow that requires CMYK images for offline catalogs, the code can be used to batch‑convert JPEGs to the correct color space.
 * 3. When integrating a digital asset management system that must store images in CMYK for consistent color reproduction across devices, this snippet shows how to perform the conversion in C# with Aspose.Imaging.
 * 4. When validating that a third‑party image processing pipeline preserves color fidelity, a developer can use the example to load a JPEG, change its ColorType to CMYK, and compare the output.
 * 5. When automating a pre‑press quality check that requires all JPEG files to be saved with 100 % quality in CMYK, the code provides a straightforward way to enforce those settings programmatically.
 */