using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jp2";
        string outputPath = "Output/sample.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load JPEG2000 image with a 1 MB memory buffer
            using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1 * 1024 * 1024 }))
            {
                // Placeholder for pixel processing if needed
                // e.g., manipulate pixels via image.SaveArgb32Pixels(...) or other APIs

                // Configure JPEG save options with 85% quality
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 85;
                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
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
 * 1. Convert high‑resolution JPEG2000 scans of archival documents to smaller JPEG files for web preview while limiting memory usage to a 1 MB buffer.
 * 2. Prepare medical imaging JPEG2000 files for integration into a hospital PACS system that only accepts JPEG with an 85 % quality setting.
 * 3. Reduce the size of satellite JPEG2000 imagery before uploading to cloud storage that requires JPEG format and specific compression quality.
 * 4. Automate batch processing of JPEG2000 product photos to generate JPEG thumbnails for an e‑commerce site using C# and Aspose.Imaging.
 * 5. Migrate legacy JPEG2000 assets in a digital asset management workflow to JPEG format with controlled 85 % quality to ensure compatibility with mobile applications.
 */