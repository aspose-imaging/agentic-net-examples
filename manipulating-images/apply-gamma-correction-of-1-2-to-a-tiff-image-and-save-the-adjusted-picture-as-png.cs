using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.tif";
            string outputPath = @"C:\temp\sample.AdjustGamma.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image, apply gamma correction, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.AdjustGamma(1.2f);
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a high‑resolution TIFF scan of a document to a web‑friendly PNG while brightening the image with a gamma of 1.2.
 * 2. When an imaging application must preprocess satellite TIFF imagery by applying gamma correction before saving it as PNG for downstream analysis.
 * 3. When a medical imaging system requires adjusting the contrast of a TIFF X‑ray image using gamma 1.2 and exporting it as PNG for inclusion in patient reports.
 * 4. When a photo‑editing tool automates the workflow of loading a TIFF photograph, applying a 1.2 gamma boost, and saving the result as a PNG for faster loading in browsers.
 * 5. When a batch‑processing script needs to verify the existence of a TIFF file, apply gamma correction, and generate a PNG thumbnail for a digital asset management catalog.
 */