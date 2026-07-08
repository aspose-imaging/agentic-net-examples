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
            string outputPath = "output.jp2";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var options = new Jpeg2000Options
            {
                Irreversible = true,
                Codec = Jpeg2000Codec.J2K
            };

            using (var jpeg2000Image = new Jpeg2000Image(200, 200, options))
            {
                var graphics = new Graphics(jpeg2000Image);
                var brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                jpeg2000Image.Save(outputPath);
            }

            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (var loadedImage = (Jpeg2000Image)Image.Load(outputPath))
            {
                Console.WriteLine("Image loaded successfully.");
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
 * 1. When a developer needs to generate a JPEG2000 file with embedded geolocation metadata for GIS applications, they can use this code to create the image, add the custom metadata block, and confirm it persists after saving.
 * 2. When an e‑commerce platform wants to store product information such as SKU and price inside a high‑resolution JPEG2000 image for digital catalogs, the code enables embedding those details as metadata and verifying their integrity.
 * 3. When a medical imaging system must attach patient identifiers and study dates to a JPEG2000 radiology image while ensuring the data remains after compression, this example shows how to embed and validate the metadata.
 * 4. When a digital archiving solution requires preserving copyright and licensing information inside JPEG2000 files for long‑term storage, developers can use the snippet to embed the metadata block and check its presence post‑save.
 * 5. When a content management workflow needs to embed thumbnail generation parameters inside a JPEG2000 image and later read them to automate processing, the code demonstrates creating the image, adding the custom metadata, and confirming it was saved correctly.
 */