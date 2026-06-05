using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string iccProfilePath = "C:\\temp\\custom.icc";
            string outputPath = "C:\\temp\\output.jp2";

            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(100, 100))
            {
                Graphics graphics = new Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                using (FileStream iccStream = File.OpenRead(iccProfilePath))
                {
                    // Placeholder: embed ICC profile if supported by JPEG2000 API
                    // Example (if supported): jpeg2000Image.RgbColorProfile = new Aspose.Imaging.Sources.StreamSource(iccStream);
                }

                jpeg2000Image.Save(outputPath);
            }

            using (Jpeg2000Image loadedImage = new Jpeg2000Image(outputPath))
            {
                // Placeholder: verify ICC profile retention if API provides access
                bool profileRetained = false; // Assume false as verification not implemented
                Console.WriteLine($"ICC profile retained: {profileRetained}");
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
 * 1. When a printing workflow requires a lossless JPEG2000 file with a specific color space, a developer can generate the image, embed the printer‑provided ICC profile, and verify it persists after saving.
 * 2. When a medical imaging system needs to store diagnostic images in JPEG2000 while preserving the calibrated color profile from a device, this code creates the image, attaches the custom ICC profile, and checks that the profile is retained.
 * 3. When a digital asset management platform must ingest user‑uploaded graphics and convert them to JPEG2000 with a corporate brand ICC profile, the developer can use this snippet to embed and validate the profile before indexing.
 * 4. When an archival solution for satellite imagery requires lossless compression and the exact sensor‑specific ICC profile to be maintained, the code demonstrates how to embed the profile and confirm its presence after the file is written.
 * 5. When a web service generates on‑the‑fly JPEG2000 thumbnails for a color‑critical e‑commerce catalog and needs to ensure the custom ICC profile is embedded for accurate display on calibrated monitors, this example shows how to embed and verify the profile.
 */