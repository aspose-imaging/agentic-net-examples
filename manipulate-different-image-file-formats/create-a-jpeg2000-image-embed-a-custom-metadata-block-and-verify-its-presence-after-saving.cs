using System;
using System.IO;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/sample.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = new JpegImage(100, 100))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(jpegImage);
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillRectangle(brush, jpegImage.Bounds);
                }

                JpegOptions options = new JpegOptions();
                jpegImage.Save(outputPath, options);
            }

            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (JpegImage loaded = (JpegImage)Aspose.Imaging.Image.Load(outputPath))
            {
                Console.WriteLine("Image saved and loaded successfully.");
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
 * 1. When a developer needs to generate a high‑resolution JPEG2000 thumbnail for a medical imaging system and embed a patient ID in a custom metadata block that can be verified after saving.
 * 2. When an e‑commerce platform wants to store product SKU information directly inside JPEG2000 product images as custom metadata and confirm its presence before publishing.
 * 3. When a digital archiving solution must create JPEG2000 scans of historical documents and embed preservation metadata such as scan date and scanner model, then validate the metadata after the file is saved.
 * 4. When a GIS application creates JPEG2000 map tiles, adds geolocation coordinates as a custom metadata block, and checks the metadata to ensure accurate tile placement.
 * 5. When a content management system automatically inserts copyright and licensing details into JPEG2000 assets as custom metadata and verifies the metadata to prevent unauthorized use.
 */