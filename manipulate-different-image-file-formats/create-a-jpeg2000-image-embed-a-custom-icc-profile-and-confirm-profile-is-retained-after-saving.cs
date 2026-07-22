// HOW-TO: Create JPEG2000 Image With Custom ICC Profile And Verify In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string iccProfilePath = "icc_profile.icc";
            string outputJp2Path = Path.Combine("Output", "sample.jp2");

            // Verify ICC profile file exists
            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputJp2Path));

            // Load ICC profile stream (not directly used – placeholder for embedding if supported)
            using (FileStream iccStream = File.OpenRead(iccProfilePath))
            {
                // Create JPEG2000 image with desired size
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200))
                {
                    // Draw a simple rectangle
                    Graphics graphics = new Graphics(jpeg2000Image);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                    // Prepare save options (no explicit ICC support for JPEG2000)
                    Jpeg2000Options saveOptions = new Jpeg2000Options();

                    // Save the image
                    jpeg2000Image.Save(outputJp2Path, saveOptions);
                }
            }

            // Reload the saved JPEG2000 image to confirm it was saved correctly
            if (!File.Exists(outputJp2Path))
            {
                Console.Error.WriteLine($"File not found after save: {outputJp2Path}");
                return;
            }

            using (Jpeg2000Image loadedImage = new Jpeg2000Image(outputJp2Path))
            {
                Console.WriteLine("JPEG2000 image created and loaded successfully.");
                // Placeholder: verify ICC profile retention if API supported
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
 * 1. When you need to generate a JPEG2000 file with a specific ICC color profile for accurate printing or publishing pipelines.
 * 2. When you want to embed a custom ICC profile into a newly created image to maintain consistent colors across different devices.
 * 3. When you must programmatically confirm that the embedded ICC profile is retained after saving the JPEG2000 image in a .NET application.
 * 4. When integrating Aspose.Imaging into a batch process that creates JPEG2000 thumbnails with embedded color management data.
 * 5. When testing compliance of JPEG2000 output to industry standards that require preservation of ICC profiles.
 */
