// HOW-TO: Extract Multi‑Page TIFF Frames To Separate JPEGs With Quality 80 In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\multpage.tif";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex + 1}.jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80,
                        Source = new FileCreateSource(outputPath, false)
                    })
                    {
                        tiff.ActiveFrame = frame;
                        tiff.Save(outputPath, jpegOptions);
                    }

                    pageIndex++;
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
 * 1. When you need to convert a scanned multi‑page TIFF document into individual JPEG images for quick web preview.
 * 2. When a medical imaging system stores patient scans as a multi‑page TIFF and you must extract each slice as a JPEG for integration with a viewer.
 * 3. When an archival workflow requires separating each page of a TIFF manuscript into high‑quality JPEG files before running OCR.
 * 4. When a printing service receives multi‑page TIFF proofs and must deliver each page as a JPEG with controlled compression.
 * 5. When a mobile app needs to display individual pages of a TIFF comic book as JPEG thumbnails with a specific quality setting.
 */
