using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\rotated.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                raster.Rotate(33f, true, Color.FromArgb(255, 128, 128, 128));
                raster.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to generate a rotated thumbnail of a user‑uploaded JPEG for a legacy Windows application that only accepts BMP files, they can load the JPEG, rotate it 33° with a gray fill, and save it as BMP.
 * 2. When an automated batch‑processing service must align scanned documents that are slightly skewed and store the corrected images in BMP format for downstream OCR tools, this code rotates each image by 33 degrees and pads the empty space with a neutral gray background.
 * 3. When a game engine requires sprite assets in BMP with a specific orientation, a developer can use this snippet to load a source PNG or JPG, rotate it 33 degrees, fill the background with gray, and output a BMP ready for the engine.
 * 4. When a reporting system creates printable charts as JPEGs but the printer driver only supports BMP and expects a fixed rotation, the code loads the chart, rotates it 33 degrees, applies a gray background, and saves the result as BMP.
 * 5. When a migration script converts legacy image archives to BMP while correcting a known 33‑degree misalignment in the original scans, the developer can employ this code to load each file, rotate it, fill missing pixels with gray, and store the corrected BMP.
 */