using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image bmpImage = Aspose.Imaging.Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiffImage = (TiffImage)Aspose.Imaging.Image.Create(tiffOptions, bmpImage.Width, bmpImage.Height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(tiffImage);
                    graphics.DrawImage(bmpImage, 0, 0);
                    tiffImage.Grayscale();
                    tiffImage.Save(outputPath);
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
 * 1. When a developer needs to convert legacy BMP scans of engineering drawings into lossless grayscale TIFF files for long‑term archival compliance.
 * 2. When an application must generate grayscale TIFF copies of user‑uploaded BMP photos to reduce file size while preserving image fidelity for document management systems.
 * 3. When a medical imaging workflow requires transforming BMP microscope images into grayscale TIFF format for compatibility with PACS archives.
 * 4. When a batch‑processing tool has to apply a grayscale filter to BMP assets before storing them as TIFF to meet regulatory requirements for immutable records.
 * 5. When a .NET service needs to read a BMP logo, convert it to a grayscale TIFF, and save it to a secure output folder for digital preservation.
 */