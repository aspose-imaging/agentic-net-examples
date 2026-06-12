using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.cdr";
            string outputPath = "output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 pixels
                image.Resize(1024, 768);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer must automate the conversion of CorelDRAW (CDR) artwork to JPEG images sized exactly 1024 × 768 pixels for inclusion in a web gallery using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform requires on‑the‑fly resizing of uploaded CDR product mockups to a standard 1024 × 768 JPEG format before storing them in the media library.
 * 3. When a content management system needs to generate preview JPEGs of legacy CDR files at a fixed resolution of 1024 × 768 for faster page loading and consistent layout.
 * 4. When a batch‑processing script must ensure all converted CDR files meet a 1024 × 768 pixel requirement for printing proofs, using Aspose.Imaging’s Resize and JpegOptions in C#.
 * 5. When a mobile app backend has to deliver uniformly sized 1024 × 768 JPEG thumbnails derived from CDR source files to maintain a consistent user experience across devices.
 */