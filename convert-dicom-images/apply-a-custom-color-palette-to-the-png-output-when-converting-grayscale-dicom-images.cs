// HOW-TO: Convert Grayscale DICOM to PNG with Custom Color Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.dcm";
            string outputPath = "Output\\image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                dicom.Grayscale();

                Color[] palette = new Color[]
                {
                    Color.Black,
                    Color.White,
                    Color.Red,
                    Color.Green,
                    Color.Blue
                };

                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = new ColorPalette(palette),
                    Source = new FileCreateSource(outputPath, false)
                };

                dicom.Save(outputPath, options);
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
 * 1. When you need to display medical DICOM scans on web pages using a limited set of colors for faster loading.
 * 2. When you want to generate PNG thumbnails of grayscale DICOM images with specific brand colors for a radiology reporting system.
 * 3. When you must convert DICOM images to an indexed‑color PNG to meet a legacy viewer’s palette restrictions.
 * 4. When you are building a C# application that archives DICOM files as small PNG files with a custom palette for visual inspection.
 * 5. When you need to apply a predefined color map to grayscale DICOM data before saving it as a PNG for scientific visualization.
 */
